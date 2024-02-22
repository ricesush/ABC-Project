using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.ShopWeb.Home;

public partial class Details
{
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] ProductService_SQL ProductService_SQL { get; set; }

    [SupplyParameterFromQuery(Name = "product")]
    public string ProductName { get; set; }

    [SupplyParameterFromQuery(Name = "id")]
    public int ProductId { get; set; }

    public Product Product { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var _products = await ProductService_SQL.GetProductInfo(applicationDbContext, ProductId);
        if (_products != null)
        {
            Product = _products;
        }

        await InvokeAsync(StateHasChanged);
    }




}