using System;
using Serilog;
using ABC.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ABC.Shared.Services;
public partial class POSService_SQL : ComponentBase, IDisposable
{
    #region DICTIONARIES 
    #endregion

    #region FIELDS
    public String AbcDbConnection { get; set; } = String.Empty;

    
    #endregion

    #region QUERY RUNNERS/CALLERS
    public async Task GetCustomerInfo()
    {
        try
        {
            // await GetAllCustomerInformation();
        }
        catch(Exception ex)
        {
            Log.Error(ex.ToString());
        }
    }


    public async Task<bool> GetCustomerList(dynamic DBContext, Customer customer)
    {
        bool HasAdded = false;
        try
        {
            bool customerList = await GetCustomerListData(DBContext, customer);
            return HasAdded;
        }
        catch(Exception ex)
        {
            Log.Error(ex.ToString());
            return HasAdded;
        }
    }


    public void Dispose()
    {
        
    }
    #endregion
}