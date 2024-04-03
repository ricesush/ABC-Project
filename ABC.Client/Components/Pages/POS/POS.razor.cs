using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Serilog;

using Microsoft.AspNetCore.Components;
using ABC.Client.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using ABC.Shared.Utility;
using ABC.Client.Components.Pages.ShopWeb.Cart.OrderCheckout;
using System.Linq.Expressions;

namespace ABC.Client.Components.Pages.POS;
public partial class POS
{
    #region DEPENDENCY INJECTIOn
    [Inject] POSService_SQL pOSService_SQL { get; set; }
    [Inject] ProductService_SQL ProductService_SQL { get; set; }
    [Inject] OrderHeaderService_SQL OrderHeaderService_SQL { get; set; }
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] UserManager<ApplicationUser> UserManager { get; set; }
    [Inject] CustomerService_SQL CustomerService_SQL { get; set; }
    private ApplicationUser applicatioUser { get; set; } = new();

    #endregion

    #region FIELDS
    private CancellationTokenSource _tokenSource = null;
    private List<CustomerBasicInfo> CustomerList { get; set; } = [];
    private List<Product> ProductList { get; set; } = [];
    private List<OrderDetail> ShoppingCart { get; set; } = [];
    private Product ProductInModal { get; set; } = new();
    private OrderHeader OrderSummary { get; set; } = new();
    private CustomerData Customer { get; set; } = new();
    private decimal TotalFees { get; set; } = 0;
    private String ProductSearchInput { get; set; } = String.Empty;
    private Discount discount { get; set; } = new();
    private DiscountModel DiscountTypes { get; set; } = new();
    private int ItemPostRemovalId { get; set; } = 0;
    private bool ShowDropdown { get; set; } = false;
    private bool ShowProductDropdown { get; set; } = false;
    private double AmountTendered { get; set; }
    private double Change { get; set; }
    #endregion
    protected override async Task OnInitializedAsync()
    {
        pOSService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
    }

    private async Task ProcessPurchase()
    {
    }
    private async Task ShowDropdownHandler(bool show)
    {
        await Task.Delay(1000);
        ShowDropdown = show;
        StateHasChanged();
    }

    private async Task ShowProductDropdownHandler(bool show)
    {
        await Task.Delay(1000);
        ShowProductDropdown = show;
        StateHasChanged();
    }

    private async Task GetCustomerList(ChangeEventArgs e)
    {
        Customer.ContactNumber = e?.Value?.ToString();
        CustomerList.Clear();

        var result = await pOSService_SQL.GetCustomerList(applicationDbContext);
        if (result is not null && result.Count > 0 && !String.IsNullOrEmpty(Customer.ContactNumber))
        {
            foreach (var item in result)
            {
                if (item.ContactNumber.ToString().StartsWith(Customer.ContactNumber, StringComparison.CurrentCultureIgnoreCase))
                {
                    CustomerBasicInfo customerBasicInfo = new()
                    {
                        Id = item.Id.ToString(),
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        ContactNumber = Convert.ToInt64(item.ContactNumber)
                    };
                    CustomerList.Add(customerBasicInfo);
                }
            }
        }
        await InvokeAsync(StateHasChanged);
    }

    private async Task GetProductList(ChangeEventArgs e)
    {
        ProductSearchInput = e?.Value?.ToString();
        ProductList.Clear();

        var result = await pOSService_SQL.GetProductList(applicationDbContext);
        if (result is not null && result.Count > 0 && !String.IsNullOrEmpty(ProductSearchInput))
        {
            ProductList = result
                .Where(x => x.productName.ToString().StartsWith(ProductSearchInput, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        await InvokeAsync(StateHasChanged);
    }

    private async Task PopulateFormData(string id)
    {
        var result = await pOSService_SQL.GetCustomerInfo(applicationDbContext, id);
        Customer = new()
        {
            Id = result.Id,
            FirstName = result.FirstName,
            LastName = result.LastName,
            EmailAddress = result.EmailAddress,
            ContactNumber = result.ContactNumber.ToString(),
            Type = result.Type,
            ApSuUn = result.ApSuUn,
            StreetorSubd = result.StreetorSubd,
            Barangay = result.Barangay,
            City = result.City,
            Province = result.Province,
            ZipCode = result.ZipCode,
        };
    }

    private async Task PopulateProductDetails(int productId)
    {
        ProductInModal = new();
        // Find the Item
        var result = await pOSService_SQL.GetProductInfo(applicationDbContext, productId);
        if (result is not null)
        {
            ProductInModal = result;
        }
    }

    private async Task AddToCart(int productId, int quantity)
    {
        // Find the Item
        if (quantity == 0)
        {
            return;
        };

        var existingItem = ShoppingCart.FirstOrDefault(x => x.Product.Id == productId);
        if (existingItem != null)
        {
            // Update quantity directly to the new input value
            existingItem.Count = quantity;
            existingItem.TotalPrice = existingItem.Count * existingItem.Price;
        }
        else
        {
            // Add the new item to the cart
            var result = await pOSService_SQL.GetProductInfo(applicationDbContext, productId);
            if (result != null)
            {
                OrderDetail newItem = new()
                {
                    Id = result.Id,
                    Product = result,
                    Count = quantity,
                    Price = result.RetailPrice,
                    TotalPrice = quantity * result.RetailPrice
                };
                ShoppingCart.Add(newItem);
            }
        }

        ProductSearchInput = "";
        await UpdateOrderSummary();
        await InvokeAsync(StateHasChanged);
    }
    public void CancelFees()
    {
        // Reset the service fee and delivery fee to zero
        OrderSummary.ServiceFee = 0;
        OrderSummary.DeliveryFee = 0;

        // Recalculate total fees
        UpdateTotalFees();
    }

    private async Task ItemPostRemoval(int productId)
    {
        ItemPostRemovalId = productId;
    }

    private async Task RemoveFromCart()
    {
        var item = ShoppingCart.FirstOrDefault(x => x.Product.Id == ItemPostRemovalId);
        if (item != null && item.Count > 0)
        {
            ShoppingCart.Remove(item);
            await UpdateOrderSummary(); 
            await InvokeAsync(StateHasChanged);
        }
    }
    
    private async Task UpdateTotalFees()
    {
        TotalFees = OrderSummary.ServiceFee + OrderSummary.DeliveryFee;
        await InvokeAsync(StateHasChanged);
    }

    private async Task UpdatePostTotalDiscount(string discountType = "percent")
    {
        decimal orderTotal = 0;
        foreach (var product in ShoppingCart)
        {
            orderTotal += Convert.ToDecimal(product.TotalPrice);
        }

        if (String.IsNullOrEmpty(discountType))
        {
            discountType = "percent";
        }
        discount.DiscountType = discountType;
        if (discountType == "percent")
        {
            discount.TotalDiscount = Convert.ToDouble(orderTotal) * (discount.DiscountAmount / 100);
        }
        else
        {
            discount.TotalDiscount = discount.DiscountAmount;
        }
        discount.DiscountedPrice = Convert.ToDouble(orderTotal) - discount.TotalDiscount;
        await InvokeAsync(StateHasChanged);
    }

    private async Task UpdateTotalDiscount()
    {
        OrderSummary.Discount = Convert.ToDecimal(discount.TotalDiscount);
        await UpdateOrderSummary();
        await InvokeAsync(StateHasChanged);
    }

    private async Task UpdateOrderSummary()
    {
        decimal orderTotal = 0;
        foreach (var product in ShoppingCart)
        {
            orderTotal += Convert.ToDecimal(product.TotalPrice);
        }
        orderTotal += (OrderSummary.ServiceFee + OrderSummary.DeliveryFee) - OrderSummary.Discount;
        OrderSummary.OrderTotal = Convert.ToDouble(orderTotal);
    }

    private async Task PaymentMethodHandler(string PaymentMethod)
    {
		switch (PaymentMethod)
		{
			case SD.PaymentModeBank:
                OrderSummary.PaymentMode = SD.PaymentModeBank;
				break;
			default:
				OrderSummary.PaymentMode = SD.PaymentModeCash;
				break;
		}
	}
    private void CalculateChange(ChangeEventArgs e)
    {
        if (double.TryParse(e.Value.ToString(), out double amountTendered))
        {
            AmountTendered = amountTendered;
            Change = OrderSummary.OrderTotal - AmountTendered;
        }
        else
        {
            Change = 0; // Handle invalid input
        }
    }
    private void SelectedCustomerTypeChanged(ChangeEventArgs e)
    {
        if (e.Value is not null)
        {
            Customer.Type = (string)e.Value;
        }
    }

    private async Task CompleteOrder()
    {
		Customer customer = new()
        {
            Id = Customer.Id,
            FirstName = Customer.FirstName,
            LastName = Customer.LastName,
            EmailAddress = Customer.EmailAddress,
            ContactNumber = Convert.ToInt64(Customer.ContactNumber),
            ApSuUn = Customer.ApSuUn,
            StreetorSubd = Customer.StreetorSubd,
            Barangay = Customer.Barangay,
            City = Customer.City,
            Province = Customer.Province,
            ZipCode = Customer.ZipCode,
            Type = Customer.Type
        };
        Customer _customer = await CustomerService_SQL.GetCustomerInfo(applicationDbContext, Customer.Id);
        if (_customer.ContactNumber == 0)
        {
            bool newCustomer = await CustomerService_SQL.AddCustomer(applicationDbContext, customer);
            _customer = await CustomerService_SQL.GetCustomerInfo(applicationDbContext, Customer.Id);
        }
        

        OrderHeader _orderHeader = new()
        {
            //OrderDetails = orderDetails,
            OrderDate = DateTime.UtcNow.ToLocalTime(),
            ShippingDate = DateTime.UtcNow.ToLocalTime().AddDays(2),
            OrderTotal = OrderSummary.OrderTotal,
            OrderStatus = SD.StatusCompleted,
            PaymentStatus = SD.PaymentStatusApproved, 
            Carrier = OrderSummary.Carrier,
            Discount = OrderSummary.Discount,
            ServiceFee = OrderSummary.ServiceFee,
            DeliveryFee = OrderSummary.DeliveryFee,
            PaymentMode = OrderSummary.PaymentMode,
            OfficialReceipt = OrderSummary.OfficialReceipt,
            Customer = _customer
        };

        bool added = await OrderHeaderService_SQL.AddOrderHeader(applicationDbContext, _orderHeader);

        List<OrderDetail> orderDetails = new();
        foreach (var item in ShoppingCart)
        {
            OrderDetail orderDetail = new()
            {
                ProductId = item.Id,
                //Id = item.Product.Id,
                //Product = item.Product,
                OrderHeaderId = _orderHeader.Id,
                Price = item.Price,
                Count = item.Count
            };
            orderDetails.Add(orderDetail);
        }
        bool addedOrderDetail = await OrderHeaderService_SQL.AddOrderDetail(applicationDbContext, orderDetails);
        await InvokeAsync(StateHasChanged);

    }
}