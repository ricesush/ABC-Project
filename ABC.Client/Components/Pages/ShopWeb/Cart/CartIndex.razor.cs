using ABC.Client.Components.Pages.Sales_Inventory.Product;
using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.ShopWeb.Cart;

public partial class CartIndex
{
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] ShoppingCartService_SQL shoppingCartService_SQL { get; set; }
	[Inject] ProductService_SQL productService_SQL { get; set; }

	[CascadingParameter]
	public HttpContext? HttpContext { get; set; }

	private List<ShoppingCart> shoppingCartList { get; set; } = [];

	private Product Product { get; set; } = new();


	protected override async Task OnInitializedAsync()
	{
		string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value;

		shoppingCartService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
		shoppingCartList = await shoppingCartService_SQL.GetShoppingCartList(applicationDbContext, userId);
	}

	private async Task UpdateShoppingCart(ShoppingCart shoppingCart)
	{
		bool updated = await shoppingCartService_SQL.UpdateShoppingCart(applicationDbContext, shoppingCart);
	}

	private async Task RemoveShoppingCart(ShoppingCart shoppingCart)
	{
		bool removed = await shoppingCartService_SQL.RemoveShoppingCart(applicationDbContext, shoppingCart);
	}

}