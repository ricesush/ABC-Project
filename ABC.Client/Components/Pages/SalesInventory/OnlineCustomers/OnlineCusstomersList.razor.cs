using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using ABC.Shared.Utility;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.SalesInventory.OnlineCustomers;

public partial class OnlineCusstomersList
{
    #region INJECTIONS
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] ApplicationUserService_SQL applicationUserService_SQL { get; set; }
    #endregion

    #region FIELDS
    private List<ApplicationUser> OnlineCustomers { get; set; } = [];
    #endregion

    protected override async Task OnInitializedAsync()
    {
        applicationUserService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await LoadCustomers();
    }

    private async Task LoadCustomers()
    {
        var users = await applicationUserService_SQL.GetApplicationUserList(applicationDbContext);
        OnlineCustomers = users.Where(u => u.Role == SD.Role_Customer).ToList();
    }
}
