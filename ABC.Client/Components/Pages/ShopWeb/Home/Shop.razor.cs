using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using MySqlX.XDevAPI.Common;

namespace ABC.Client.Components.Pages.ShopWeb.Home;

public partial class Shop
{
	#region Injections
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] ProductService_SQL productService_SQL { get; set; }
	[Inject] CategoryService_SQL categoryService_SQL { get; set; }

	#endregion

	#region fields
	private List<Product> Products { get; set; } = [];

	private List<Category> categories = [];

	private Product Product { get; set; } = new();
	private Category Category { get; set; } = new();
	
	#endregion

	#region
	protected override async Task OnInitializedAsync()
	{
		Products = await productService_SQL.GetProductList(applicationDbContext);
		categories = await categoryService_SQL.GetCategoryListData(applicationDbContext);

	}	

	#endregion

}
