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

    }

    private async Task ProcessPurchase(){
        if(!String.IsNullOrEmpty(Customer.FirstName)){
            await InsertCustomer();
        }else{
            // await Process
        }
    }

    private async Task GetCustomerList(){
        var result = await pOSService_SQL.GetCustomerList(applicationDbContext);
        if(result is not null && result.Count > 0){
            foreach(var item in result ){
                CustomerBasicInfo customerBasicInfo = new(){
                    Id = item.Id.ToString(),
                    FirstName =  item.FirstName,
                    LastName = item.LastName,
                    ContactNumber = Convert.ToInt32(item.ContactNumber)
                };
                CustomerList.Add(customerBasicInfo);
            }
        }
    }

    private async Task GetCustomerInfo(string id){
        var result = await pOSService_SQL.GetCustomerInfo(applicationDbContext, id);
            
    }

    private async Task AddCustomer(){
        try
        {
            Customer customer = new()
            {
                FirstName = "",
                LastName = "Esan",
                EmailAddress = "admintest@test.com",
                ContactNumber = 09995514412,
                ApSuUn = "IDK",
                Type = "User",
                StreetorSubd = "Tokyo St.",
                Barangay = "Tokyo",
                City = "Tokyo",
                Province = "Tokyo",
                ZipCode = 1114
            };
            
            var result = await pOSService_SQL.GetCustomerList(applicationDbContext, customer);
            // if(result is not null){
            //     CustomerList = result;
            // }
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
        }
    }
}