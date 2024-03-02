using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

using System.Security.Claims;

namespace ABC.Client.Components.Pages.ShopWeb.Home;

public partial class Details
{
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] ProductService_SQL ProductService_SQL { get; set; }
    [Inject] ShoppingCartService_SQL ShoppingCartService_SQL { get; set; }


    [SupplyParameterFromQuery(Name = "product")]
    public string ProductName { get; set; }

    [SupplyParameterFromQuery(Name = "id")]
    public int ProductId { get; set; }

    //public Product Product { get; set; }
    private string ValidationMessage { get; set; }

    [SupplyParameterFromForm]
    public ShoppingCart ShoppingCartFormModel { get; set; }

    [CascadingParameter]
    public HttpContext? HttpContext { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ShoppingCartFormModel ??= new();

        var _products = await ProductService_SQL.GetProductInfo(applicationDbContext, ProductId);
        if (_products != null)
        {
            ShoppingCartFormModel.Product = _products;
            //Product = _products;
        }
        await InvokeAsync(StateHasChanged);
    }

    private async Task AddShoppingCart()
    {
        ShoppingCartFormModel.ApplicationUserId = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value;
        ShoppingCartFormModel.ProductName = ShoppingCartFormModel.Product.productName;
        bool added = await ShoppingCartService_SQL.AddShoppingCart(applicationDbContext, ShoppingCartFormModel);
    }

}