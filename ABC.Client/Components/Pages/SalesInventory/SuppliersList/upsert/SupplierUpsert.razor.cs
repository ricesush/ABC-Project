using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.SalesInventory.SuppliersList.upsert;

public partial class SupplierUpsert
{
    #region INJECTIONS
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] SupplierService_SQL supplierService_SQL { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    #endregion

    #region FIELDS
    private List<Supplier> Suppliers { get; set; } = [];
    private List<Store> StoreList { get; set; } = [];
    private Supplier SelectedSupplier { get; set; } = new();

    [SupplyParameterFromQuery(Name = "id")]
    public int supplierId { get; set; }
    #endregion

    protected override async Task OnInitializedAsync()
    {
        supplierService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await LoadSupplier();
    }

    private async Task LoadSupplier()
    {
        var supplierTask = supplierService_SQL.GetSupplierInfo(applicationDbContext, supplierId);
        SelectedSupplier = await supplierTask;
    }

    private async Task SaveSupplier()
    {
        if (SelectedSupplier.Id == 0)
        {
            bool added = await supplierService_SQL.AddSupplier(applicationDbContext, SelectedSupplier);
            NavigationManager.NavigateTo("/SupplierList", true);
        } else
        {
            bool updated = await supplierService_SQL.UpdateSupplier(applicationDbContext, SelectedSupplier);
			NavigationManager.NavigateTo("/SupplierList", true);
		}
    }
}
