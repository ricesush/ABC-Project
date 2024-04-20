using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Reflection.Emit;
using ABC.Shared.Utility;
using Serilog;

namespace ABC.Client.Components.Pages.SalesInventory.OrderPage.details;
public partial class Details
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
	private decimal charges;
	bool showOtherReason = false;
	string otherReason = "";
	private bool reason1Selected;
	private bool reason2Selected;
	private bool reason3Selected;
	private string prodName;
	#endregion

	protected override async Task OnInitializedAsync()
	{
		orderHeaderService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;

		orderDetailsList = await orderHeaderService_SQL.GetOrderDetailsList(applicationDbContext, OrderId);
		await LoadProducts();
		StateHasChanged();
	}

	private async Task LoadProducts()
	{
		orderHeader = await orderHeaderService_SQL.GetOrderHeader(applicationDbContext, OrderId);

		if (orderHeader.ApplicationUser != null)
		{
			firstName = orderHeader.ApplicationUser.FirstName;
			phoneNumber = orderHeader.ApplicationUser.PhoneNumber;
			lineAddress = orderHeader.ApplicationUser.Address;
			province = orderHeader.ApplicationUser.Province;
			zipCode = orderHeader.ApplicationUser.PostalCode;
			email = orderHeader.ApplicationUser.Email;
		}
		else if (orderHeader.Customer != null)
		{
			firstName = orderHeader.Customer.FirstName;
			phoneNumber = orderHeader.Customer.ContactNumber.ToString();
			lineAddress = orderHeader.Customer.ApSuUn;
			province = orderHeader.Customer.Province;
			zipCode = orderHeader.Customer.ZipCode.ToString();
			email = orderHeader.Customer.EmailAddress;
		}

		charges = orderHeader.DeliveryFee + orderHeader.ServiceFee;
	}

	private async Task SaveOrder()
	{

	}

	private async Task StartProcessing()
	{
		orderHeader.OrderStatus = SD.StatusProcessing;
		orderHeader.ProcessDate = DateTime.UtcNow;

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
		orderHeader.ShippingDate = DateTime.UtcNow;

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
		orderHeader.CompletionDate = DateTime.UtcNow;
		//orderHeader.EmployeeName = 

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
		orderHeader.CancellationDate = DateTime.UtcNow;

		// Call service to update OrderHeader
		bool updated = await orderHeaderService_SQL.UpdateOrderHeaderStatus(applicationDbContext, orderHeader);

		if (updated)
		{
			//refresh the list
			StateHasChanged();
		}
	}

	private async Task RefundOrder(int Id)
	{
		orderHeader.OrderStatus = SD.StatusRefunded;
		await orderHeaderService_SQL.UpdateOrderHeaderStatus(applicationDbContext, orderHeader);

		selectedOrder = await orderHeaderService_SQL.GetOrderDetail(applicationDbContext, Id);
		AddReasons();

		// Call service to update OrderHeader
		bool updated = await orderHeaderService_SQL.UpdateOrderDetailStatus(applicationDbContext, selectedOrder);

		if (updated)
		{
			// Reset all reason checkboxes and otherReason
			ResetReasons();
			StateHasChanged();
		}
	}

	#region REFUND METHODS
	private async Task PopulateOrder(int Id)
	{
		selectedOrder = new();

		// Find the Item
		var result = await orderHeaderService_SQL.GetOrderDetail(applicationDbContext, Id);

		if (result is not null)
		{
			selectedOrder = result;
			prodName = selectedOrder.Product.productName;
		}
		await InvokeAsync(StateHasChanged);
	}


	private void AddReasons()
	{
		// Build the Remarks based on selected reasons
		List<string> selectedReasons = new List<string>();
		if (reason1Selected)
		{
			selectedReasons.Add("Item not as described");
		}
		if (reason2Selected)
		{
			selectedReasons.Add("Item damaged during shipment");
		}
		if (reason3Selected)
		{
			selectedReasons.Add("Wrong item received");
		}
		if (!string.IsNullOrEmpty(otherReason))
		{
			selectedReasons.Add(otherReason);
		}

		selectedOrder.Remark = string.Join(", ", selectedReasons);
	}


	private void ResetReasons()
	{
		reason1Selected = false;
		reason2Selected = false;
		reason3Selected = false;
		otherReason = "";
	}

	void ShowOtherReason()
	{
		showOtherReason = !showOtherReason;
	}
	#endregion
}

