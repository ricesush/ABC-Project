using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC.Shared.Models;
using ABC.Shared.Services;
using Serilog;

using Microsoft.AspNetCore.Components;
using ABC.Client.Data;
using System.Diagnostics;

namespace ABC.Client.Components.Pages.POS;
public partial class POS
{
    #region DEPENDENCY INJECTIOn
    [Inject] POSService_SQL pOSService_SQL { get; set; }
    [Inject] ApplicationDbContext applicationDbContext { get; set; }
    private Customer Customer { get; set; } = new();
    #endregion

    #region FIELDS
    private List<CustomerBasicInfo> CustomerList { get; set; } = [];
    #endregion
    protected override async Task OnInitializedAsync()
    {
        pOSService_SQL.AbcDbConnection = AppSettingsHelper.AbcDbConnection;
        await pOSService_SQL.GetCustomerList(applicationDbContext);
    }

    private async Task ProcessPurchase(){
        if(!String.IsNullOrEmpty(Customer.FirstName)){
            await AddCustomer();
        }else{
            // await Process
        }
    }

    private async Task GetCustomerList(){

    }

    private async Task AddCustomer(){
        try
        {
            Customer customer = new()
            {
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                EmailAddress = Customer.EmailAddress,
                ContactNumber = Customer.ContactNumber,
                ApSuUn = Customer.ApSuUn,
                Type = Customer.Type,
                StreetorSubd = Customer.StreetorSubd,
                Barangay = Customer.Barangay,
                City = Customer.City,
                Province = Customer.Province,
                ZipCode = Customer.ZipCode
            };
            var result = await pOSService_SQL.AddCustomer(applicationDbContext, customer);
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
        }
    }
}