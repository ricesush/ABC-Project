using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using ABC.Shared.Utility;
using Microsoft.AspNetCore.Components;

namespace ABC.Client.Components.Pages.SalesInventory.EmployeesList;

public partial class EmployeesList
{
    #region INJECTIONS
    [Inject] ApplicationDbContext applicationDbContext {  get; set; }
    [Inject] ApplicationUserService_SQL applicationUserService_SQL { get; set; }
    #endregion
    #region FIELDS
    private List<ApplicationUser> employeeUsers { get; set; } = [];
    #endregion

    protected override async Task OnInitializedAsync()
    {
        applicationUserService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        var users = await applicationUserService_SQL.GetApplicationUserList(applicationDbContext);
        employeeUsers = users.Where(u => u.Role != SD.Role_Customer).ToList();
    }
}
