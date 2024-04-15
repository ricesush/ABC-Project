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
using System.Globalization;

namespace ABC.Client.Components.Pages.SalesInventory.Dashboard;
public partial class Dashboard
{
	#region INJECTIONS
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
	[Inject] ProductService_SQL productService_SQL { get; set; }
	[Inject] CustomerService_SQL customerService_SQL { get; set; }
	[Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
	[Inject] AuditService_SQL auditService_SQL { get; set; }
	#endregion

	#region FIELDS
	// Lists
	private List<Customer> customersList { get; set; } = new List<Customer>();
	private List<OrderHeader> orderHeadersList { get; set; } = new List<OrderHeader>();
	private List<Product> productsList { get; set; } = new List<Product>();
	private List<Product> BestSellingProducts { get; set; } = new();
	private List<(Product Product, int Count)> Products { get; set; } = new List<(Product, int)>();
	// Parameters
	private int totalcustomers;
	private int unprocessedOrders;
	private int ordersoutfordelivery;
	private int cancelledOrders;

	private int totalProducts;
	private int instock;
	private int lowstock;
	private int outofstock;

	private double AddsomeSales;
	private double AheadBizSales;
	#endregion

	protected override async Task OnInitializedAsync()
	{
		productsList = await productService_SQL.GetProductList(applicationDbContext);
		orderHeadersList = await orderHeaderService_SQL.GetOrdersList(applicationDbContext);
		customersList = await customerService_SQL.GetCustomersList(applicationDbContext);

		totalProducts = productsList.Count();
		unprocessedOrders = orderHeadersList.Count(o => o.OrderStatus == SD.StatusPending);
		ordersoutfordelivery = orderHeadersList.Count(o => o.OrderStatus == SD.StatusShipped);
		cancelledOrders = orderHeadersList.Count(o => o.OrderStatus == SD.StatusCancelled);
		instock = productsList.Count(p => p.status == SD.InStock);
		lowstock = productsList.Count(p => p.status == SD.LowStock);
		outofstock = productsList.Count(p => p.status == SD.OutOfStock);
		totalcustomers = customersList.Count();

		//AddsomeSales = await CalculateSalesByStore(1);
		//AheadBizSales = await CalculateSalesByStore(2);

		await LoadBestSelling();
	}
	//private async Task<double> CalculateSalesByStore(int storeId)
	//{
	//	double salesByStore = 0;

	//	var completedOrders = orderHeadersList.Where(o => o.OrderStatus == SD.StatusCompleted);

	//	foreach (var order in completedOrders)
	//	{
	//		if (order.OrderDetails == null || order.OrderDetails.Count == 0)
	//		{
	//			await applicationDbContext.Entry(order).Collection(o => o.OrderDetails).LoadAsync();
	//		}
	//		var orderDetailsByStore = order.OrderDetails.Where(od => od.Product.StoreId == storeId); //od.storeID

	//		salesByStore += order.OrderDetails.Sum(od => od.Count * od.Price); //od.
	//	}

	//	return salesByStore;
	//}

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