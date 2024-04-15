using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Utility;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ABC.Client.Components.Pages.SalesInventory.SalesReport;

public partial class SalesReport
{
    #region Injections
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] ProductService_SQL productService_SQL { get; set; }
    [Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
    [Inject] ApplicationUserService_SQL applicationUserSevice_SQL { get; set; }
    [Inject] CustomerService_SQL customerService_SQL { get; set; }
    [Inject] IJSRuntime JSRuntime { get; set; }
    #endregion

    #region Fields
    private List<OrderHeader> orderHeadersList { get; set; } = [];
    private List<OrderDetail> orderDetails { get; set; } = [];
    private List<Product> productsList { get; set; } = [];
    private Product Product { get; set; }

    //parameters
    private double totalSales;
    private double AddsomeSales;
    private double AheadSales;

    private double grossProfit;
    private double AddsomeProfit;
    private double AheadBizProfit;

    private int productsSold;
    private int AddsomeProductsSold;
    private int AheadProductsSold;
    private List<(Product Product, int Count)> Products { get; set; } = new List<(Product, int)>();
    private DateTime startDate = DateTime.Today.AddDays(-7);
    private DateTime endDate = DateTime.Today;
    #endregion

    protected override async Task OnInitializedAsync()
    {
        productsList = await productService_SQL.GetProductList(applicationDbContext);
        orderHeadersList = await orderHeaderService_SQL.GetOrdersList(applicationDbContext);

        totalSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted).Sum(o => o.OrderTotal);
        AddsomeSales = await CalculateSalesByStore(1);
        AheadSales = await CalculateSalesByStore(2);

        grossProfit = await CalculateGrossProfit();
        AddsomeProfit = await CalculateGrossProfitByStore(1);
        AheadBizProfit = await CalculateGrossProfitByStore(2);

        productsSold = await CalculateSoldProducts();
        AddsomeProductsSold = await CalculateSoldProductsByStore(1);
        AheadProductsSold = await CalculateSoldProductsByStore(2);

        await LoadBestSelling();
    }

    private async Task<double> CalculateGrossProfit()
    {
        double profit = 0;

        var completedOrders = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted);

        foreach (var order in completedOrders)
        {
            if (order.OrderDetails == null || order.OrderDetails.Count == 0)
            {
                await applicationDbContext.Entry(order).Collection(o => o.OrderDetails).LoadAsync();
            }

            foreach (var orderDetail in order.OrderDetails)
            {
                await applicationDbContext.Entry(orderDetail).Reference(od => od.Product).LoadAsync();
            }

            profit += order.OrderDetails.Sum(od => od.Count * (od.Product.RetailPrice - od.Product.CostPrice));
        }

        return profit;
    }

    private async Task<double> CalculateGrossProfitByStore(int storeId)
    {
        double profit = 0;

        var completedOrders = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted);

        //foreach (var order in completedOrders)
        //{
        //    if (order.OrderDetails == null || order.OrderDetails.Count == 0)
        //    {
        //        await applicationDbContext.Entry(order).Collection(o => o.OrderDetails).LoadAsync();
        //    }

        //    foreach (var orderDetail in order.OrderDetails)
        //    {
        //        await applicationDbContext.Entry(orderDetail).Reference(od => od.Product).LoadAsync();
        //    }

        //    var orderDetailsByStore = order.OrderDetails.Where(od => od.Product.StoreId == storeId);

        //    profit += orderDetailsByStore.Sum(od => od.Count * (od.Product.RetailPrice - od.Product.CostPrice));
        //}

        return profit;
    }

    private async Task<int> CalculateSoldProducts()
    {
        int totalSold = 0;

        var completedOrders = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted);

        foreach (var order in completedOrders)
        {
            if (order.OrderDetails == null || order.OrderDetails.Count == 0)
            {
                await applicationDbContext.Entry(order).Collection(o => o.OrderDetails).LoadAsync();
            }

            totalSold += order.OrderDetails.Sum(od => od.Count);
        }

        return totalSold;
    }

    private async Task<double> CalculateSalesByStore(int storeId)
    {
        double salesByStore = 0;

        var completedOrders = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted);

        //foreach (var order in completedOrders)
        //{
        //    if (order.OrderDetails == null || order.OrderDetails.Count == 0)
        //    {
        //        await applicationDbContext.Entry(order).Collection(o => o.OrderDetails).LoadAsync();
        //    }
        //    var orderDetailsByStore = order.OrderDetails.Where(od => od.Product.StoreId == storeId);

        //    salesByStore += orderDetailsByStore.Sum(od => od.Count * od.Product.RetailPrice);
        //}

        return salesByStore;
    }

    private async Task<int> CalculateSoldProductsByStore(int storeId)
    {
        int soldByStore = 0;

        //var soldProducts = productsList
        //    .Where(p => p.StoreId == storeId)
        //    .Select(p => p.Id);

        //var completedOrders = orderHeadersList
        //    .Where(o => o.OrderStatus == SD.StatusCompleted);

        //foreach (var order in completedOrders)
        //{
        //    if (order.OrderDetails == null || order.OrderDetails.Count == 0)
        //    {
        //        await applicationDbContext.Entry(order).Collection(o => o.OrderDetails).LoadAsync();
        //    }

        //    soldByStore += order.OrderDetails
        //        .Where(od => soldProducts.Contains(od.ProductId))
        //        .Sum(od => od.Count);
        //}

        return soldByStore;
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
