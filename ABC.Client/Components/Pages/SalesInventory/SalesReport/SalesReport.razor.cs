using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Utility;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ABC.Client.Components.Pages.SalesInventory.SalesReport;

public partial class SalesReport
{
    #region Injections
    [Inject] ApplicationDbContext applicationDbContext {  get; set; }
    [Inject] ProductService_SQL productService_SQL { get; set; }
    [Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
    [Inject] IJSRuntime JSRuntime { get; set; }
    #endregion

    #region Fields
    private List<OrderHeader> orderHeadersList { get; set; } = [];
    private List<Product> productsList { get; set; } = [];
    private Product Product { get; set; }

    private Dictionary<string, int> bestSellingProducts = new Dictionary<string, int>();

    //parameters
    private double totalSales;
    private double costs;
    private double grossProfit;

    private double walkinSales;
    private double oncallSales;
    private double chatSales;
    private double shopWebSales;

    private int products_Sold;

    #endregion

    protected override async Task OnInitializedAsync()
    {
        // Retrieve data from services
        productsList = await productService_SQL.GetProductList(applicationDbContext);
        orderHeadersList = await orderHeaderService_SQL.GetOrdersList(applicationDbContext);

        totalSales = CalculateTotalSales(orderHeadersList);
        costs = CalculateTotalCosts(productsList);
        grossProfit = totalSales - costs;
        products_Sold = CalculateSoldProducts(orderHeadersList);

        // Calculate best-selling products
        CalculateBestSellingProducts(orderHeadersList);
    }

    private void CalculateBestSellingProducts(List<OrderHeader> orders)
    {
        Dictionary<int, int> productSalesCount = new Dictionary<int, int>(); 

        foreach (var order in orders)
        {
            if (order.OrderStatus == SD.StatusCompleted)
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    if (productSalesCount.ContainsKey(orderDetail.ProductId))
                    {
                        productSalesCount[orderDetail.ProductId] += orderDetail.Count;
                    }
                    else
                    {
                        productSalesCount[orderDetail.ProductId] = orderDetail.Count;
                    }
                }
            }
        }

        // Sort the products by sales count to get the best-selling ones
        var sortedProducts = productSalesCount.OrderByDescending(p => p.Value);

        // Extract product names and quantities for display
        foreach (var product in sortedProducts)
        {
            var productName = productsList.FirstOrDefault(p => p.Id == product.Key)?.productName;
            if (!string.IsNullOrEmpty(productName))
            {
                bestSellingProducts[productName] = product.Value;
            }
        }
    }

    private double CalculateTotalSales(List<OrderHeader> orders)
    {
        double totalRevenue = 0;

        foreach (var order in orders)
        {
            totalRevenue += order.OrderTotal;
        }

        return totalRevenue;
    }

    private double CalculateTotalCosts(List<Product> products)
    {
        double total = 0;

        foreach (var product in products)
        {
            total += product.CostPrice;
        }

        return total;
    }

    private int CalculateSoldProducts(List<OrderHeader> orders)
    {
        int totalproduct = 0;

        foreach (var order in orders)
        {
            if (order.OrderStatus == SD.StatusCompleted)
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    totalproduct += orderDetail.Count;
                }
            }
        }

        return totalproduct;
    }
}
