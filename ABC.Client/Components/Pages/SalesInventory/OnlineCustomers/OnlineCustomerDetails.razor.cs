using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.SalesInventory.OnlineCustomers;

public partial class OnlineCustomerDetails
{
    #region Injections
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] ApplicationUserService_SQL applicationUserService_SQL { get; set; }
    [Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
    [Inject] ProductService_SQL productService_SQL { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    #endregion
    #region Fields
    private List<ApplicationUser> OnlineCustomers { get; set; } = [];
    private List<Store> StoreList { get; set; } = [];
    private ApplicationUser SelectedCustomer { get; set; } = new();

    [SupplyParameterFromQuery(Name = "id")]
    public string onlineCustomerId { get; set; }

    string onlineCustId;
    #endregion

    protected override async Task OnInitializedAsync()
    {
        applicationUserService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await LoadOnlineCustomer();
    }

    private async Task LoadOnlineCustomer()
    {
        var customerTask = applicationUserService_SQL.GetApplicationUserInfo(applicationDbContext, onlineCustomerId);

        SelectedCustomer = await customerTask;
    }
}
