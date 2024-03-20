using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.SalesInventory.CustomerList;

public partial class CustomerList
{
	#region INJECTIONS
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] CustomerService_SQL customerService_SQL {  get; set; }
	#endregion

	#region FIELDS
	private List<Customer> Customers { get; set; } = [];
	#endregion

	protected override async Task OnInitializedAsync()
	{
		customerService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
		await LoadCustomers();
	}

	private async Task LoadCustomers()
	{
		Customers = await customerService_SQL.GetCustomersList(applicationDbContext);
	}
}
