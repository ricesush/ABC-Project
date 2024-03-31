using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.SalesInventory.PurchaseOrdersPage;

public partial class PO_Upsert
{
	#region Injections
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] PurchaseOrderService_SQL purchaseOrderService_SQL { get; set; }
	[Inject] SupplierService_SQL supplierService_SQL { get; set; }
	[Inject] StoreService_SQL storeService_SQL { get; set; }
	[Inject] ProductService_SQL productService_SQL { get; set; }
	#endregion

	#region Fields
	private List<Product> Products { get; set; } = [];
	private List<Supplier> SupplierList { get; set; } = [];
	private List<Store> StoreList { get; set; } = [];

	[SupplyParameterFromQuery(Name = "id")]
	public int PurchaseOrderID { get; set; }

	private PurchaseOrder selectedPurchaseOrder { get; set; } = new();
	#endregion

	protected override async Task OnInitializedAsync()
	{
		productService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
		await LoadPurchaseOrder();
	}

	private async Task LoadPurchaseOrder()
	{
		// Load product information, category list, store list, and supplier list concurrently
		var purchaseTask = purchaseOrderService_SQL.GetPurchaseOrderInfo(applicationDbContext, PurchaseOrderID);

		// Await all tasks simultaneously
		selectedPurchaseOrder = await purchaseTask;
	}

	private async Task SavePurchaseOrder()
	{

	}

}
