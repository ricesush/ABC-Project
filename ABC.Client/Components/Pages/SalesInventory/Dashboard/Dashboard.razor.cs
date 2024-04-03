using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Implementation;
using Microsoft.JSInterop;
using System.Security.Claims;
using ABC.Shared.Utility;

namespace ABC.Client.Components.Pages.SalesInventory.Dashboard;
public partial class Dashboard
{
	#region INJECTIONS
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
	[Inject] ProductService_SQL productService_SQL { get; set; }
	[Inject] CustomerService_SQL customerService_SQL { get; set; }
    [Inject] IJSRuntime JSRuntime { get; set; }
    [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject] AuditService_SQL auditService_SQL { get; set; }
    #endregion

    #region FIELDS
    // Lists
    private List<Customer> customersList { get; set; } = new List<Customer>();
	private List<OrderHeader> orderHeadersList { get; set; } = new List<OrderHeader>();
	private List<Product> productsList { get; set; } = new List<Product>();
    private List<Product> BestSellingProducts { get; set; } = new();
    // Parameters
    private int totalcustomers;
	private int unprocessedOrders;
	private int ordersoutfordelivery;
	private int cancelledOrders;

	private int totalProducts;
	private int instock;
	private int lowstock;
	private int outofstock;

	private double salesRevenue;
	private double totalCost;

	#endregion

	protected override async Task OnInitializedAsync()
	{
        var completedOrders = orderHeadersList.Where(o => o.OrderStatus == "Completed");
        // Retrieve data from services
        productsList = await productService_SQL.GetProductList(applicationDbContext);
		orderHeadersList = await orderHeaderService_SQL.GetOrdersList(applicationDbContext);
		customersList = await customerService_SQL.GetCustomersList(applicationDbContext);

        salesRevenue = completedOrders.Sum(o => o.OrderTotal);
        totalProducts = productsList.Count();
		unprocessedOrders = orderHeadersList.Count(o => o.OrderStatus == "Pending");
		ordersoutfordelivery = orderHeadersList.Count(o => o.OrderStatus == "Out for Delivery");
		cancelledOrders = orderHeadersList.Count(o => o.OrderStatus == "Cancelled");
        instock = productsList.Count(p => p.status == "Active");
		lowstock = productsList.Count(p => p.status == SD.LowStock);
        outofstock = productsList.Count(p => p.status == SD.OutOfStock);

        totalcustomers = customersList.Count();

		await LoadBestSelling();
    }

    private async Task LoadBestSelling()
    {
        BestSellingProducts = await applicationDbContext.OrderDetails
                       .Include(detail => detail.Product)
                       .GroupBy(detail => detail.Product)
                       .OrderByDescending(group => group.Sum(detail => detail.Count))
                       .Select(group => group.Key)

                       .ToListAsync();

        await InvokeAsync(StateHasChanged);
    }
}