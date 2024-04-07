using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.SalesInventory.StockTransfers;

public partial class StockTransferList
{
    #region Injections
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] StockTransferService_SQL stockTransferService_SQL { get; set; }
    [Inject] StoreService_SQL storeService_SQL { get; set; }
    [Inject] ProductService_SQL productService_SQL { get; set; }
    #endregion

    #region FIELDS
    private List<StockTransfer> stockTransfers { get; set; } = [];
    private StockTransfer selectedStockTransfer { get; set; } = new();
    private string newStatus;
    public int selectedStockTransferID { get; set; }
    #endregion

    protected override async Task OnInitializedAsync()
    {
        stockTransferService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await LoadPurchaseOrders();
    }

    private async Task LoadPurchaseOrders()
    {
        stockTransfers = await stockTransferService_SQL.GetStockTransferList(applicationDbContext);
    }

    private async Task PopulatePO_Details(int stockTransferId)
    {
        selectedStockTransfer = new();

        var result = await stockTransferService_SQL.GetStockTransferInfo(applicationDbContext, stockTransferId);

        if (result is not null)
        {
            selectedStockTransfer = result;
        }

        await InvokeAsync(StateHasChanged);
    }

    private void UpdateStatusModalHandler(string status, int stockTransferId)
    {
        newStatus = status;
        selectedStockTransferID = stockTransferId;
    }

    private async Task UpdateStatusHandler()
    {
        StockTransfer stockTransfer = stockTransfers.FirstOrDefault(p => p.Id == selectedStockTransferID);
        if (stockTransfer != null)
        {
            stockTransfer.Status = newStatus;
            bool updated = await stockTransferService_SQL.UpdateStockTransfer(applicationDbContext, stockTransfer, productService_SQL);
        }
    }
}
