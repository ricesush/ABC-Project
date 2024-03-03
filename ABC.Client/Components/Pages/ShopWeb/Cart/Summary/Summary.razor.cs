using ABC.Client.Components.Pages.Sales_Inventory.Product;
using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Serilog;

namespace ABC.Client.Components.Pages.ShopWeb.Cart.OrderCheckout;
public partial class Summary
{
	#region Injections
	[Inject] IHttpContextAccessor httpContextAccessor { get; set; }
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] ShoppingCartService_SQL shoppingCartService_SQL { get; set; } //papalitan ng vm
	[Inject] ProductService_SQL productService_SQL { get; set; }

	[Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
	#endregion

	#region Fields
	[CascadingParameter]
	public HttpContext? HttpContext { get; set; }
	private List<ShoppingCart> shoppingCartList { get; set; } = [];

	public ShoppingCart shoppingCart { get; set; }
	public OrderHeader orderHeader { get; set; }
	public OrderDetail orderDetail { get; set; }
	public ApplicationUser user { get; set; }

	[SupplyParameterFromForm]
	public OrderHeader checkoutFormModel { get; set; }
	#endregion

	protected override async Task OnInitializedAsync()
	{
		checkoutFormModel ??= new();

		string userId = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value;
		shoppingCartList = await shoppingCartService_SQL.GetShoppingCartList(applicationDbContext, userId);

		//// Create a new order header based on the shopping cart
		//orderHeader = new OrderHeader
		//{
		//	//CustomerId = customer.Id, // Assuming you have a customer object
		//	//OrderDetails = shoppingCart.Items.Select(cartItem => new OrderDetail
		//	//{
		//	//	ProductId = cartItem.Product.Id,
		//	//	Count = cartItem.Quantity,
		//	//	// Set other properties like Price, etc.
		//	//}).ToList()
		//};
	}

	private async Task AddOrderHeader()
	{
		checkoutFormModel.ApplicationUserId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value;
		bool added = await orderHeaderService_SQL.AddOrderHeader(applicationDbContext, checkoutFormModel);
	}
}
