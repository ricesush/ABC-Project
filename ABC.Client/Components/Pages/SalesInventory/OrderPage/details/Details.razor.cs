using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Reflection.Emit;
using ABC.Shared.Utility;

namespace ABC.Client.Components.Pages.SalesInventory.OrderPage.details;
public partial class Details
{
	#region DEPENDENCY INJECTIOn
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
	#endregion

	#region fields
	private Toast toastRef;
	private List<OrderDetail> orderDetailsList { get; set; } = [];
	private OrderHeader orderHeader { get; set; } = new();

	[SupplyParameterFromQuery(Name = "id")]
	public int OrderId { get; set; }

	#endregion

	#region Variables
	private string? firstName;
	private string? phoneNumber;
	private string? lineAddress;
	private string? city;
	private string? province;
	private string? zipCode;
	private string? email;

	#endregion

	protected override async Task OnInitializedAsync()
	{
		orderHeaderService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;

		orderDetailsList = await orderHeaderService_SQL.GetOrderDetailsList(applicationDbContext, OrderId);
		await LoadProducts();
	}
	private async Task LoadProducts()
	{
		orderHeader = await orderHeaderService_SQL.GetOrderHeader(applicationDbContext, OrderId);
		firstName = orderHeader.ApplicationUser?.FirstName;
		phoneNumber = orderHeader.ApplicationUser?.PhoneNumber;
		lineAddress = orderHeader.ApplicationUser?.Address;
		province = orderHeader.ApplicationUser?.Province;
		zipCode = orderHeader.ApplicationUser?.PostalCode;
		email = orderHeader.ApplicationUser?.Email;
	}

	private async Task SaveOrder()
	{
		
	}

	private async Task StartProcessing()
	{
		orderHeader.OrderStatus = SD.StatusProcessing;

		// Call service to update OrderHeader
		bool updated = await orderHeaderService_SQL.UpdateOrderHeaderStatus(applicationDbContext, orderHeader);

		if (updated)
		{
			//refresh the list
			StateHasChanged();
		}
	}

	private async Task DeliverOrder()
	{
        if (string.IsNullOrWhiteSpace(orderHeader.Carrier))
        {
			toastRef.ShowToast("Note", "Please enter a delivery personnel");
			return;
		}

		orderHeader = await orderHeaderService_SQL.GetOrderHeader(applicationDbContext, OrderId);
		orderHeader.Carrier = orderHeader.Carrier;
		orderHeader.OrderStatus = SD.StatusShipped;
		orderHeader.ShippingDate = DateTime.Now;

		// Call service to update OrderHeader
		bool updated = await orderHeaderService_SQL.UpdateOrderHeaderStatus(applicationDbContext, orderHeader);

		if (updated)
		{
			//refresh the list
			StateHasChanged();
		}
	}
	private async Task OrderPaid()
	{
		orderHeader = await orderHeaderService_SQL.GetOrderHeader(applicationDbContext, OrderId);
		orderHeader.OrderStatus = SD.StatusCompleted;
		orderHeader.PaymentStatus = SD.StatusCompleted;

		// Call service to update OrderHeader
		bool updated = await orderHeaderService_SQL.UpdateOrderHeaderStatus(applicationDbContext, orderHeader);

		if (updated)
		{
			//refresh the list
			StateHasChanged();
		}
	}

	private async Task CancelOrder()
	{
		orderHeader = await orderHeaderService_SQL.GetOrderHeader(applicationDbContext, OrderId);
		orderHeader.OrderStatus = SD.StatusCancelled;

		// Call service to update OrderHeader
		bool updated = await orderHeaderService_SQL.UpdateOrderHeaderStatus(applicationDbContext, orderHeader);

		if (updated)
		{
			//refresh the list
			StateHasChanged();
		}
	}
}

