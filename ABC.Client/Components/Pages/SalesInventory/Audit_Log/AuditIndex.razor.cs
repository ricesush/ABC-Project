using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Microsoft.AspNetCore.Components;
using System.Security.AccessControl;

namespace ABC.Client.Components.Pages.SalesInventory.Audit_Log;

public partial class AuditIndex
{
	#region INJECTIONS
	[Inject] AuditService_SQL AuditService_SQL { get; set; }
	[Inject] ApplicationDbContext applicationDbContext { get; set; }
	[Inject] ApplicationUserService_SQL ApplicationUserService_SQL { get; set; }
	#endregion

	#region FIELDS
	private List<AuditLog> Audits { get; set; } = [];
	private ApplicationUser User { get; set; }
	#endregion

	protected override async Task OnInitializedAsync()
	{
        Audits = await AuditService_SQL.GetAuditList(applicationDbContext);
    }
}