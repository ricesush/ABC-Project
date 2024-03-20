using ABC.Client.Data;
using ABC.Shared.Models;
using ABC.Shared.Models.ViewModels;
using ABC.Shared.Services;
using ABC.Shared.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics;
using System.Security.Claims;

namespace ABC.Client.Components.Pages.SalesInventory.SalesRecord;

public partial class SalesRecord
{
    #region DEPENDENCY INJECTIOn
    [Inject] ProductService_SQL productService_SQL { get; set; }
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    [Inject] ApplicationUserService_SQL applicationUserService_SQL { get; set; }

    [Inject] OrderHeaderService_SQL orderHeaderService_SQL { get; set; }
    [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject] IHttpContextAccessor HttpContextAccessor { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    #endregion

    #region FIELDS
    private string activeStatus = "completed"; // Track the active status
    private string cancelled { get; set; } = "text-danger";
    private string completed { get; set; } = "text-success";
    private string refunded { get; set; } = "text-secondary";


    public HttpContext? HttpContext { get; set; }
    private string userId;
    private List<OrderHeader> OrderHeader { get; set; } = new List<OrderHeader>();
    public ApplicationUser User { get; set; }
    #endregion

    protected override async Task OnInitializedAsync()
    {
        orderHeaderService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await LoadProducts();
        SetActiveStatus(activeStatus);
    }

    private async Task LoadProducts()
    {
        OrderHeader = await orderHeaderService_SQL.GetOrdersList(applicationDbContext);
        FilterOrdersByStatus(activeStatus);
    }

    private async Task SetActiveStatus(string status)
    {
        activeStatus = status;
        cancelled = "text-primary";
        completed = "text-primary";
        refunded = "text-primary";

        switch (status)
        {
            case "cancelled":
                cancelled = "active text-white bg-danger";
                break;
            case "completed":
                completed = "active text-white bg-success";
                break;
            case "refunded":
                refunded = "active text-white bg-secondary";
                break;
            default:
                completed = "active text-white bg-primary";
                break;
        }

        FilterOrdersByStatus(status);
    }

    private async Task FilterOrdersByStatus(string status)
    {
        OrderHeader = await orderHeaderService_SQL.GetOrdersList(applicationDbContext);

        switch (status)
        {
            case "cancelled":
                OrderHeader = OrderHeader.Where(o => o.OrderStatus == SD.StatusCancelled).ToList();
                break;
            case "completed":
                OrderHeader = OrderHeader.Where(o => o.OrderStatus == SD.StatusCompleted).ToList();
                break;
            case "refunded":
                OrderHeader = OrderHeader.Where(o => o.OrderStatus == SD.StatusRefunded).ToList();
                break;
            default:
                break;
        }
    }
}

