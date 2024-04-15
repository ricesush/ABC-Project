﻿using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;


namespace ABC.Client.Components.Pages.SalesInventory.CustomerList.upsert;
public partial class CustomerUpsert
{
    #region INJECTIONS
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] CustomerService_SQL customerService_SQL { get; set; }
    [Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
    [Inject] ProductService_SQL productService_SQL { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    #endregion

    #region FIELDS
    private List<OrderHeader> OrderHeaders { get; set; } = new List<OrderHeader>();
    private Customer SelectedCustomer { get; set; } = new();

    [SupplyParameterFromQuery(Name = "id")]
    public Guid CustomerId { get; set; }

	string customerId;
	#endregion

	protected override async Task OnInitializedAsync()
    {
        customerService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await LoadCustomer();
    }

	private async Task LoadCustomer()
	{
		if (Guid.TryParse(customerId, out Guid guidValue))
		{
			CustomerId = guidValue;
		}
		else
		{
			// Handle invalid input (e.g., display error message)
		}
		var customerTask = customerService_SQL.GetCustomerInfo(applicationDbContext, CustomerId);

		SelectedCustomer = await customerTask;
	}
}
