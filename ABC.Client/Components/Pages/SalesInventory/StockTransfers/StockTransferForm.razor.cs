using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Serilog;

namespace ABC.Client.Components.Pages.SalesInventory.StockTransfers;

public partial class StockTransferForm
{
	#region Injections
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] StockTransferService_SQL stockTransferService_SQL { get; set; }
	[Inject] StoreService_SQL storeService_SQL { get; set; }
	[Inject] ProductService_SQL productService_SQL { get; set; }
	[Inject] NavigationManager navigationManager { get; set; }
	#endregion

	#region FIELDS
	private List<Store> StoreList { get; set; }

	[SupplyParameterFromForm]
	public StockTransfer selectedStockTransfer { get; set; } = new();

	[SupplyParameterFromQuery(Name = "id")]
	public int StockTransferID { get; set; } = 0;
	#endregion

	protected override async Task OnInitializedAsync()
	{
		try
		{
			selectedStockTransfer ??= new();
			stockTransferService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
			await LoadStockTransfer();
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
		}

	}
	private async Task LoadStockTransfer()
	{
		try
		{
			var stockTransferTask = stockTransferService_SQL.GetStockTransferInfo(applicationDbContext, StockTransferID);
			selectedStockTransfer = await stockTransferTask;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
		}
	}

	private async Task SaveStockTransfer()
	{
		try
		{
			if (selectedStockTransfer.Id == 0)
			{
				bool added = await stockTransferService_SQL.AddstockTransfer(applicationDbContext, selectedStockTransfer);
				navigationManager.NavigateTo("/StockTransfer", true);
			}
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
		}
	}

	private async Task CancelAction()
	{
		try
		{
			if (selectedStockTransfer.Id != 0)
			{
				selectedStockTransfer = await stockTransferService_SQL.GetStockTransferInfo(applicationDbContext, selectedStockTransfer.Id);
				navigationManager.NavigateTo("/StockTransfer", true);
			}
			else
			{
				selectedStockTransfer = new StockTransfer();
				navigationManager.NavigateTo("/StockTransfer", true);
			}
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
		}
	}
}