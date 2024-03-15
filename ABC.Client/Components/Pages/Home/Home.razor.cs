using ABC.Client.Components.Pages.SalesInventory.ProductPage;
using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using MySqlX.XDevAPI.Common;

namespace ABC.Client.Components.Pages.Home;
public partial class Home
{
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] ProductService_SQL productService_SQL { get; set; }
    [Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }

    #region fields
    private List<Product> ProductList { get; set; } = [];
    private List<OrderDetail> topSellingItems { get; set; } = [];

    #endregion

    #region
    protected override async Task OnInitializedAsync()
    {
        productService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        ProductList = await productService_SQL.GetProductList(applicationDbContext);
    }

    private async Task GetProductList()
    {
        var result = await productService_SQL.GetProductList(applicationDbContext);

        if (result is not null && result.Count > 0)
        {
            ProductList = result.OrderByDescending(x => x.DateAdded).ToList();
        }

        await InvokeAsync(StateHasChanged);
    }

    #endregion
}