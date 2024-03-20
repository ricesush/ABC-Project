using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.SalesInventory.Dashboard;

public partial class Dashboard
{
	#region INJECTIONS
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
	[Inject] ProductService_SQL productService_SQL { get; set; }
	[Inject] CustomerService_SQL customerService_SQL { get; set; }
	#endregion

	#region FIELDS
	// Lists
	private List<Customer> customersList { get; set; } = new List<Customer>();
	private List<OrderHeader> orderHeadersList { get; set; } = new List<OrderHeader>();
	private List<Product> productsList { get; set; } = new List<Product>();

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
		// Retrieve data from services
		productsList = await productService_SQL.GetProductList(applicationDbContext);
		orderHeadersList = await orderHeaderService_SQL.GetOrdersList(applicationDbContext);
		customersList = await customerService_SQL.GetCustomersList(applicationDbContext);

		totalProducts = productsList.Count();
		unprocessedOrders = orderHeadersList.Count(o => o.OrderStatus == "Pending");
		ordersoutfordelivery = orderHeadersList.Count(o => o.OrderStatus == "Out for Delivery");
		cancelledOrders = orderHeadersList.Count(o => o.OrderStatus == "Cancelled");

		totalcustomers = customersList.Count();
	}
}