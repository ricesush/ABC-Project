using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.SalesInventory.PurchaseOrdersPage;

public partial class PurchaseOrderList
{
    #region Injections
    [Inject] PurchaseOrderService_SQL PurchaseOrderService_SQL { get; set; }
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    #endregion

    #region Fields
    private List<PurchaseOrder> purchaseOrders { get; set; } = [];

    #endregion

    protected override async Task OnInitializedAsync()
    {
        PurchaseOrderService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        purchaseOrders = await PurchaseOrderService_SQL.GetPurchaseOrderList(applicationDbContext);
    }

}
