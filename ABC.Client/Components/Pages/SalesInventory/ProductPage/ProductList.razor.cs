using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using ABC.Shared.Utility;
using System.Diagnostics;


namespace ABC.Client.Components.Pages.SalesInventory.ProductPage;

public partial class ProductList
{
	#region DEPENDENCY INJECTIOn
	[Inject] ProductService_SQL productService_SQL { get; set; }
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
	[Inject] AuditService_SQL auditService_SQL { get; set; }
	#endregion

	#region fields
	private string activeStore = "all"; // Track the active status
	private string all { get; set; } = "text-primary";
	private string addsome { get; set; } = "text-primary";
	private string ahead { get; set; } = "text-primary";

	private List<Product> Products { get; set; } = [];
	private Product selectedProduct { get; set; } = new();
	private String ProductSearchInput { get; set; } = String.Empty;

	#endregion

	protected override async Task OnInitializedAsync()
	{
		productService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
		await LoadProducts();
		SetActiveStore(activeStore);
	}

	private async Task LoadProducts()
	{
		Products = await productService_SQL.GetProductList(applicationDbContext);
		FilterOrdersByStore(activeStore);
	}

	private async Task GetProductList(ChangeEventArgs e)
	{
		ProductSearchInput = e?.Value?.ToString();

		var result = await productService_SQL.GetProductList(applicationDbContext);
		if (result is not null && result.Count > 0 && !String.IsNullOrEmpty(ProductSearchInput))
		{
			Products = result.Where(x => x.productName.ToString().Contains(ProductSearchInput, StringComparison.CurrentCultureIgnoreCase)).ToList();
		}
		else
		{
			Products = result.ToList();
		}
		await InvokeAsync(StateHasChanged);
	}

	private async Task SetActiveStore(string storeName)
	{
		activeStore = storeName;
		all = "text-primary";
		addsome = "text-primary";
		ahead = "text-primary";

		switch (storeName)
		{
			case "addsome":
				addsome = "active text-white bg-primary";
				break;
			case "ahead":
				ahead = "active text-white bg-primary";
				break;
			default:
				all = "active text-white bg-primary";
				break;
		}

		FilterOrdersByStore(storeName);
	}

	private async Task FilterOrdersByStore(string storeName)
	{
		Products = await productService_SQL.GetProductList(applicationDbContext);

		switch (storeName)
		{
			case "addsome":
				Products = Products.Where(p => p.StockPerStore.Store1StockQty >= 0).ToList();
				break;
			case "ahead":
				Products = Products.Where(p => p.StockPerStore.Store2StockQty >= 0).ToList();
				break;
			default:
				Products = Products.Where(p => p.StockQuantity >= 0).ToList();
				break;
		}
	}

	private async Task PopulateProductDetails(int productId)
	{
		selectedProduct = new();
		var result = await productService_SQL.GetProductInfo(applicationDbContext, productId);
		if (result is not null)
		{
			selectedProduct = result;
		}
		await InvokeAsync(StateHasChanged);
	}
	private async Task Remove()
	{
		var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
		var user = authState.User;
		var userName = user.FindFirst(ClaimTypes.Name)?.Value;
		var userRole = user.FindFirst(ClaimTypes.Role)?.Value;

		DateTime utcTime = DateTime.UtcNow;
		TimeZoneInfo dtzi = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
		DateTime pstTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, dtzi);

		// Call service to remove product 
		bool removed = await productService_SQL.RemoveProduct(applicationDbContext, selectedProduct);

		if (removed)
		{
			//refresh the list
			await LoadProducts();
			AuditLog auditLog = new AuditLog
			{
				UserName = userName,
				Action = "Removed Product",
				EntityName = "Product",
				EntityKey = selectedProduct.Id.ToString(),
				Changes = $"{selectedProduct.productName} is removed from the list.",
				Timestamp = pstTime,
				Role = userRole
			};
			await auditService_SQL.AddAudit(applicationDbContext, auditLog);
		}
	}

}

