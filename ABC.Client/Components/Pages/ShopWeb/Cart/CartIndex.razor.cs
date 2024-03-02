using ABC.Client.Components.Pages.Sales_Inventory.Product;
using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Serilog;

namespace ABC.Client.Components.Pages.ShopWeb.Cart;

public partial class CartIndex
{
	
	[Inject] IHttpContextAccessor httpContextAccessor { get; set; }
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] ShoppingCartService_SQL shoppingCartService_SQL { get; set; }
	[Inject] ProductService_SQL productService_SQL { get; set; }

	#region Fields
	//[SupplyParameterFromForm]
	////public ShoppingCart CartFormModel { get; set; }

	[CascadingParameter]
	public HttpContext? HttpContext { get; set; }

	private List<ShoppingCart> shoppingCartList { get; set; } = [];

	private Product Product { get; set; } = new();

	private ShoppingCart ShoppingCartToRemove { get; set; }

	[SupplyParameterFromForm]
	private ShoppingCart ShoppingCartToUpdate { get; set; }
	[SupplyParameterFromForm]
	private ShoppingCartForm ProductIdToRemove { get; set; }

	[SupplyParameterFromForm]
	private ShoppingCartForm ProductIdToUpdate { get; set; }

	private int NewQuantity { get; set; }
	private bool ShowRemoveModal { get; set; } = false;
	private bool ShowUpdateModal { get; set; } = false;
	#endregion

	protected override async Task OnInitializedAsync()
	{
		ProductIdToRemove ??= new();
		ShoppingCartToUpdate ??= new();
		string userId = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value;

		shoppingCartService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
		shoppingCartList = await shoppingCartService_SQL.GetShoppingCartList(applicationDbContext, userId);
	}

	//UPDATE
	private async Task UpdateShoppingCart(ShoppingCart shoppingCart)
	{
		try
		{
			//int newQuantity = ShoppingCartToUpdate.Quantity;

			ShoppingCartToUpdate = shoppingCart;
			ShoppingCartToUpdate.Quantity = NewQuantity;
			//ShoppingCartToUpdate = shoppingCartList.FirstOrDefault(x => x.Id == ProductIdToUpdate.Id);
			
			bool updated = await shoppingCartService_SQL.UpdateShoppingCart(applicationDbContext, ShoppingCartToUpdate);

			//Re-updating Shopping Cart List UI
			string userId = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value;
			shoppingCartList = await shoppingCartService_SQL.GetShoppingCartList(applicationDbContext, userId);

			await InvokeAsync(StateHasChanged);
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
		}
	}

	private void SetProductIdToUpdate(int productId)
	{
		UpdateModalHandler(true);
		ShoppingCartToUpdate = new();
		ShoppingCartToUpdate = shoppingCartList.FirstOrDefault(x => x.ProductId == productId);

	}

	private void UpdateModalHandler(bool show)
	{
		ShowUpdateModal = show;
	}

	//REMOVE
	private async Task RemoveShoppingCart(int id)
	{
		try 
		{
			ProductIdToRemove.Id = id;
			if(ProductIdToRemove.Id > 0)
			{
				ShoppingCartToRemove = shoppingCartList.FirstOrDefault(x => x.Id == ProductIdToRemove.Id);
				bool removed = await shoppingCartService_SQL.RemoveShoppingCart(applicationDbContext, ShoppingCartToRemove);

				string userId = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value;
				shoppingCartList = await shoppingCartService_SQL.GetShoppingCartList(applicationDbContext, userId);
			}
			await InvokeAsync(StateHasChanged);
		} 
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
		}
		//CartFormModel.Id = CartFormModel.Product.Id;
		
	}

	private void SetProductIdToRemove(int productId)
	{
		RemoveModalHandler(true);
		ShoppingCartToRemove = new();
		ShoppingCartToRemove = shoppingCartList.FirstOrDefault(x => x.ProductId == productId);

	}

	private void RemoveModalHandler(bool show)
	{
		ShowRemoveModal = show;
	}

}