using ABC.Client.Components.Pages.SalesInventory.ProductPage;
using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using ABC.Shared.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Globalization;
using System.Text;

namespace ABC.Client.Components.Pages.SalesInventory.InventoryReport;

public partial class InventoryReport
{
    #region Injections
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] ProductService_SQL productService_SQL { get; set; }
    [Inject] PurchaseOrderService_SQL purchaseOrderService_SQL { get; set; }
    [Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
    [Inject] ApplicationUserService_SQL applicationUserSevice_SQL { get; set; }
    [Inject] CustomerService_SQL customerService_SQL { get; set; }
    [Inject] IJSRuntime JSRuntime { get; set; }
    [Inject] PdfService pdfService { get; set; }
    #endregion

    #region FIELDS
    private List<Product> productsList { get; set; } = new List<Product>();
    private List<PurchaseOrder> purchaseOrders { get; set; } = new List<PurchaseOrder>();
    private List<(Product Product, int TotalStock)> Products { get; set; } = new List<(Product, int)>();

    private double totalInventoryValue;
    private double AddsomeInventoryValue;
    private double AheadBizInventoryValue;

    private int totalAvailableQuantity;
    private int AddsomeAvailableQuantity;
    private int AheadAvailableQuantity;

    private DateTime startDate = DateTime.Today.AddDays(-7);
    private DateTime endDate = DateTime.Today;
    #endregion

    protected override async Task OnInitializedAsync()
    {
        productsList = await productService_SQL.GetProductList(applicationDbContext);
        purchaseOrders = await purchaseOrderService_SQL.GetPurchaseOrderList(applicationDbContext);

        totalAvailableQuantity = productsList.Where(p => p.status == SD.InStock || p.status == SD.LowStock).Sum(p => p.StockPerStore.TotalStocks);
        AddsomeAvailableQuantity = productsList.Where(p => p.status == SD.InStock || p.status == SD.LowStock).Sum(p => p.StockPerStore.Store1StockQty);
        AheadAvailableQuantity = productsList.Where(p => p.status == SD.InStock || p.status == SD.LowStock).Sum(p => p.StockPerStore.Store2StockQty);

        totalInventoryValue = productsList.Sum(p => p.CostPrice * p.StockPerStore.TotalStocks);
        AddsomeInventoryValue = productsList.Sum(p => p.CostPrice * p.StockPerStore.Store1StockQty);
        AheadBizInventoryValue = productsList.Sum(p => p.CostPrice * p.StockPerStore.Store2StockQty);

        await LoadBestSelling();
    }

    private async Task LoadBestSelling()
    {
        var productGroups = await applicationDbContext.StockPerStores
            .Include(stock => stock.Product)
            .GroupBy(stock => stock.Product)
            .Select(group => new
            {
                Product = group.Key,
                TotalStock = group.Sum(stock => stock.TotalStocks)
            })
            .OrderByDescending(group => group.TotalStock)
            .ToListAsync();

        Products = productGroups.Select(group => (group.Product, group.TotalStock)).ToList();

        await InvokeAsync(StateHasChanged);
    }

    public string FormatCurrency(double value)
    {
        return value.ToString("C", new CultureInfo("en-PH"));
    }

    private async Task GeneratePdf()
    {
        string content = GetReportContent();
        byte[] pdfBytes = pdfService.GeneratePdf(content);

        await JSRuntime.InvokeVoidAsync("BlazorDownloadFile", "InventoryReport.pdf", Convert.ToBase64String(pdfBytes));
    }

    private string GetReportContent()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Inventory Report");
        return sb.ToString();
    }
}