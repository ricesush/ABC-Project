using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using ABC.Shared.Utility;


namespace ABC.Client.Components.Pages.SalesInventory.ProductPage;

public partial class RefundedProd
{
	#region DEPENDENCY INJECTIOn
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
	[Inject] ProductService_SQL productService_SQL { get; set; }

	#endregion

	#region fields
	private Toast toastRef;
	private List<OrderDetail> orderDetailsList { get; set; } = [];
	private OrderHeader orderHeader { get; set; } = new();
	private OrderDetail selectedOrder { get; set; } = new();
	private Product selectedProduct { get; set; } = new();


	private string? prodName;
	#endregion



	protected override async Task OnInitializedAsync()
    {
		orderHeaderService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await LoadProducts();        
    }

    private async Task LoadProducts()
    {
		orderDetailsList = await orderHeaderService_SQL.GetOrderDetailList(applicationDbContext);
	}
	private async Task PopulateOrder(int Id)
	{
		selectedOrder = new();
		selectedProduct = new();

		// Find the Item
		var result = await orderHeaderService_SQL.GetOrderDetail(applicationDbContext, Id);


		if (result is not null)
		{
			selectedOrder = result;
			prodName = selectedOrder.Product.productName;
		}

		selectedProduct = await productService_SQL.GetProductInfo(applicationDbContext, selectedOrder.ProductId);
		await InvokeAsync(StateHasChanged);
	}

	private async Task Merge()
	{
		// Add Product back to the table
		selectedProduct.StockPerStore.Store1StockQty += selectedOrder.remarkQty ?? 0;
		selectedProduct.StockPerStore.TotalStocks += selectedOrder.remarkQty ?? 0;

		await productService_SQL.UpdateProduct(applicationDbContext, selectedProduct);

		//remove order detail
		selectedOrder.status = false;
		bool updated = await orderHeaderService_SQL.UpdateOrderDetailStatus(applicationDbContext, selectedOrder);

	}
}

