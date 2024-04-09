using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.SalesInventory.PurchaseOrdersPage;

public partial class PurchaseOrderList
{
    #region Injections
    [Inject] PurchaseOrderService_SQL PurchaseOrderService_SQL { get; set; }
    [Inject] ProductService_SQL productService_SQL { get; set; }
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    #endregion

    #region Fields
    private List<PurchaseOrder> purchaseOrders { get; set; } = [];
    private PurchaseOrder selectedPurchaseOrder { get; set; } = new();
    private string newStatus;
    public int selectedPurchaseOrderId { get; set; }
    #endregion

    protected override async Task OnInitializedAsync()
    {
        PurchaseOrderService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await LoadPurchaseOrders();
    }

    private async Task LoadPurchaseOrders()
    {
        purchaseOrders = await PurchaseOrderService_SQL.GetPurchaseOrderList(applicationDbContext);
    }

    private async Task PopulatePO_Details(int purchaseOrderId)
    {
        selectedPurchaseOrder = new();

        var result = await PurchaseOrderService_SQL.GetPurchaseOrderInfo(applicationDbContext, purchaseOrderId);

        if (result is not null)
        {
            selectedPurchaseOrder = result;
        }

        await InvokeAsync(StateHasChanged);
    }

    private void UpdateStatusModalHandler(string status, int purchaseOrderId)
    {
        newStatus = status;
        selectedPurchaseOrderId = purchaseOrderId;
    }

    private async Task UpdateStatusHandler()
    {
        PurchaseOrder purchaseOrder = purchaseOrders.FirstOrDefault(p => p.Id == selectedPurchaseOrderId);
        if (purchaseOrder != null)
        {
            purchaseOrder.Status = newStatus;
            bool updated = await PurchaseOrderService_SQL.UpdatePurchaseOrder(applicationDbContext, purchaseOrder, productService_SQL);
        }
    }
}
