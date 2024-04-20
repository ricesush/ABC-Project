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
    private List<Product> productsList { get; set; } = [];

    //parameters
    private double totalSales;
    private double AddsomeSales;
    private double AheadSales;

    private double WalkInSales;
    private double OnCallSales;
    private double ChatBasedSales;
    private double ShoppingWebsiteSales;

    private double AddsomeWalkInSales;
    private double AddsomeOnCallSales;
    private double AddsomeChatBasedSales;
    private double AddsomeShoppingWebsiteSales;

    private double AheadWalkInSales;
    private double AheadOnCallSales;
    private double AheadChatBasedSales;
    private double AheadShoppingWebsiteSales;


    private double grossProfit;
    private double AddsomeProfit;
    private double AheadBizProfit;
    
    private List<(Product Product, int Count, float CostPrice, float RetailPrice)> Products { get; set; } = new List<(Product, int, float, float)>();
    private DateTime startDate = DateTime.Today.AddDays(-7);
    private DateTime endDate = DateTime.Today;
    #endregion

    protected override async Task OnInitializedAsync()
    {
        productsList = await productService_SQL.GetProductList(applicationDbContext);
        orderHeadersList = await orderHeaderService_SQL.GetOrdersList(applicationDbContext);

        totalSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted).Sum(o => o.OrderTotal);
		var (addsomeSales, aheadSales) = await CalculateSalesPerStore();
		AddsomeSales = addsomeSales;
		AheadSales = aheadSales;

		WalkInSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.WalkIn).Sum(o => o.OrderTotal);
        AddsomeWalkInSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.WalkIn && o.StoreName.Contains("Addsome")).Sum(o => o.OrderTotal);
        AheadWalkInSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.WalkIn && o.StoreName.Contains("Ahead")).Sum(o => o.OrderTotal);

        OnCallSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.OnCall).Sum(o => o.OrderTotal);
        AddsomeOnCallSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.OnCall && o.StoreName.Contains("Addsome")).Sum(o => o.OrderTotal);
        AheadOnCallSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.OnCall && o.StoreName.Contains("Ahead")).Sum(o => o.OrderTotal);

        ChatBasedSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.ChatBased).Sum(o => o.OrderTotal);
        AddsomeChatBasedSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.ChatBased && o.StoreName.Contains("Addsome")).Sum(o => o.OrderTotal);
        AheadChatBasedSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.ChatBased && o.StoreName.Contains("Ahead")).Sum(o => o.OrderTotal);

        ShoppingWebsiteSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.ShopWeb).Sum(o => o.OrderTotal);
        AddsomeShoppingWebsiteSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.ShopWeb && o.StoreName.Contains("Addsome")).Sum(o => o.OrderTotal);
        AheadShoppingWebsiteSales = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.SalesChannel == SD.ShopWeb && o.StoreName.Contains("Ahead")).Sum(o => o.OrderTotal);

        grossProfit = await CalculateGrossProfit();
        AddsomeProfit = await CalculateGrossProfitPerStore("Addsome Business Corporation");
        AheadBizProfit = await CalculateGrossProfitPerStore("Ahead Biz Computers");

        await LoadBestSelling();
    }

    private async Task<(double AddsomeSales, double AheadSales)> CalculateSalesPerStore()
	{
		double addsomeSales = 0;
		double aheadSales = 0;

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

				if (order.StoreName.Contains("Addsome"))
				{
					addsomeSales += orderDetail.Count * orderDetail.Product.RetailPrice;
				}
				else if (order.StoreName.Contains("Ahead Biz"))
				{
					aheadSales += orderDetail.Count * orderDetail.Product.RetailPrice;
				}
			}
		}

		return (addsomeSales, aheadSales);
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

            profit += order.OrderDetails.Sum(od => (od.RetailPrice - od.CostPrice) * od.Count);
        }

        return profit;
    }

    private async Task<double> CalculateGrossProfitPerStore(string storeName)
    {
        double profit = 0;

        var completedOrders = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted && o.StoreName == storeName);

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

            profit += order.OrderDetails.Sum(od => (od.RetailPrice - od.CostPrice) * od.Count);
        }

        return profit;
    }

    private async Task LoadBestSelling()
    {
        var productGroups = await applicationDbContext.OrderHeaders
            .Where(header => header.OrderStatus == SD.StatusCompleted)
            .Include(header => header.OrderDetails)
                .ThenInclude(detail => detail.Product) 
            .SelectMany(header => header.OrderDetails)
            .GroupBy(detail => detail.Product)
            .Select(group => new
            {
                Product = group.Key,
                Count = group.Sum(detail => detail.Count),
                CostPrice = group.First().Product.CostPrice, 
                RetailPrice = group.First().Product.RetailPrice,
            })
            .OrderByDescending(group => group.Count)
            .ToListAsync();

        Products = productGroups.Select(group => (group.Product, group.Count, group.CostPrice, group.RetailPrice)).ToList();

        await InvokeAsync(StateHasChanged);
    }

    public string FormatCurrency(double value)
    {
        return value.ToString("C", new CultureInfo("en-PH"));
    }
}
