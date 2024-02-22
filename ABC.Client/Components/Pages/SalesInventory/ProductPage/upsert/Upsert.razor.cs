using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;


namespace ABC.Client.Components.Pages.SalesInventory.ProductPage.upsert;
    public partial class Upsert
    {

    private readonly IWebHostEnvironment _webHostEnvironment;

    #region DEPENDENCY INJECTIOn
    [Inject] ProductService_SQL productService_SQL { get; set; }
    [Inject] CategoryService_SQL categoryService_SQL { get; set; }
    [Inject] SupplierService_SQL supplierService_SQL { get; set; }
    [Inject] StoreService_SQL storeService_SQL { get; set; }


    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    #endregion

    #region fields
    private List<Product> Products { get; set; } = [];
    private List<Category> CategoryList { get; set; } = [];
    private List<Supplier> SupplierList { get; set; } = [];
    private List<Store> StoreList { get; set; } = [];
    private Product selectedProduct { get; set; } = new();



	[SupplyParameterFromQuery(Name = "id")]
	public int ProductId { get; set; }
    #endregion


    protected override async Task OnInitializedAsync()
    {
        productService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await LoadProducts();
    }

    private async Task LoadProducts()
    {
        // Load product information, category list, store list, and supplier list concurrently
        var productTask = productService_SQL.GetProductInfo(applicationDbContext, ProductId);
        var categoryTask = categoryService_SQL.GetCategoryListData(applicationDbContext);
        var storeTask = storeService_SQL.GetStoreListData(applicationDbContext);
        var supplierTask = supplierService_SQL.GetSupplierList(applicationDbContext);

        // Await all tasks simultaneously
        selectedProduct = await productTask;
        CategoryList = await categoryTask;
        StoreList = await storeTask;
        SupplierList = await supplierTask;

    }

    private async Task SaveProduct()
    {
        if (selectedProduct.Id == 0)
        {
            // If the Id is 0, it's a new product 
            bool added = await productService_SQL.AddProduct(applicationDbContext, selectedProduct);
            NavigationManager.NavigateTo("/ProductList", true);
        }
        else
        {
            // If the Id is not 0, it's an existing product to be updated
            bool updated = await productService_SQL.UpdateProduct(applicationDbContext, selectedProduct);

            if (updated)
            {
                NavigationManager.NavigateTo("/ProductList", true);
            }
            else
            {
                //toast
            }

        }
    } 
}

