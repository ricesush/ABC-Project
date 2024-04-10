using ABC.Client.Components.Pages.SalesInventory.ProductPage;
using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using ABC.Shared.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Globalization;

namespace ABC.Client.Components.Pages.SalesInventory.InventoryReport;

public partial class InventoryReport
{
    #region Injections
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] ProductService_SQL productService_SQL { get; set; }
    [Inject] PurchaseOrderService_SQL purchaseOrderService_SQL { get; set; }
    [Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
    [Inject] ApplicationUserService_SQL applicationUserSevice_SQL { get; set; }
    [Inject] CustomerService_SQL customerService_SQL { get; set; }
    [Inject] IJSRuntime JSRuntime { get; set; }
    #endregion

    #region FIELDS
    private List<Product> productsList { get; set; } = new List<Product>();
    private List<PurchaseOrder> purchaseOrders { get; set; } = new List<PurchaseOrder>();
    private List<(Product Product, int Count)> Products { get; set; } = new List<(Product, int)>();

    private double totalInventoryValue;
    private double AddsomeInventoryValue;
    private double AheadBizInventoryValue;

    private int totalAvailableQuantity;
    private int AddsomeAvailableQuantity;
    private int AheadAvailableQuantity;

    private double totalPurchaseAmount;
    private double AddsomePurchaseAmount;
    private double AheadBizPurchaseAmount;

    private DateTime startDate = DateTime.Today.AddDays(-7);
    private DateTime endDate = DateTime.Today;
    #endregion

    protected override async Task OnInitializedAsync()
    {
        productsList = await productService_SQL.GetProductList(applicationDbContext);
        purchaseOrders = await purchaseOrderService_SQL.GetPurchaseOrderList(applicationDbContext);

        totalAvailableQuantity = productsList.Where(p => p.status == SD.InStock || p.status == SD.LowStock).Sum(p => p.StockQuantity);
        AddsomeAvailableQuantity = productsList.Where(p => (p.status == SD.InStock || p.status == SD.LowStock) && p.StockPerStore.Store1StockQty == 1).Sum(p => p.StockQuantity);
        AheadAvailableQuantity = productsList.Where(p => (p.status == SD.InStock || p.status == SD.LowStock) && p.StockPerStore.Store2StockQty == 2).Sum(p => p.StockQuantity);

        totalPurchaseAmount = purchaseOrders.Where(po => po.Status == SD.PO_Completed).Sum(po => po.OrderTotal);
        AddsomePurchaseAmount = purchaseOrders.Where(po => po.StoreId == 1 && po.Status == SD.PO_Completed).Sum(po => po.OrderTotal);
        AheadBizPurchaseAmount = purchaseOrders.Where(po => po.StoreId == 2 && po.Status == SD.PO_Completed).Sum(po => po.OrderTotal);

        await CalculateInventoryValue();
        await LoadBestSelling();
    }

    private async Task CalculateInventoryValue()
    {
        try
        {
            var products = await productService_SQL.GetProductList(applicationDbContext);

            if (products != null && products.Any())
            {
                totalInventoryValue = products.Sum(p => p.StockQuantity * p.CostPrice);

                //AddsomeInventoryValue = products
                //    .Where(p => p.Store != null && p.Store.Id == 1)
                //    .Sum(p => p.StockQuantity * p.CostPrice);

                //AheadBizInventoryValue = products
                //    .Where(p => p.Store != null && p.Store.Id == 2)
                //    .Sum(p => p.StockQuantity * p.CostPrice);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating inventory value: {ex.Message}");
        }
    }

    private async Task LoadBestSelling()
    {
        var productGroups = await applicationDbContext.OrderDetails
                    .Include(detail => detail.Product)
                    .GroupBy(detail => detail.Product)
                    .Select(group => new
                    {
                        Product = group.Key,
                        Count = group.Sum(detail => detail.Count)
                    })
                    .OrderByDescending(group => group.Count)
                    .ToListAsync();

        Products = productGroups.Select(group => (group.Product, group.Count)).ToList();

        await InvokeAsync(StateHasChanged);
    }

    public string FormatCurrency(double value)
    {
        return value.ToString("C", new CultureInfo("en-PH"));
    }
}