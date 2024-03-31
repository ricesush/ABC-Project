using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;



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
    private List<Product> Products { get; set; } = [];
    private Product selectedProduct { get; set; } = new();

    #endregion


    protected override async Task OnInitializedAsync()
    {
        productService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await LoadProducts();        
    }

    private async Task LoadProducts()
    {
        Products = await productService_SQL.GetProductList(applicationDbContext);
    }

	private async Task PopulateProductDetails(int productId)
    {
        selectedProduct = new();

        // Find the Item
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

        // Change the product's status 
        selectedProduct.status = "Inactive";

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
                FormattedTime = pstTime.ToString("yyyy-MM-dd HH:mm:ss"),
                Role = userRole
            };
            await auditService_SQL.AddAudit(applicationDbContext, auditLog);
        }
	}

}

