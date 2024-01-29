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

    public void Dispose()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region QUERY RUNNERS/CALLERS
    public async Task GetCustomerInfo()
    {
        try
        {
            await GetAllCustomerInformation("authToken", "status");
        }
        catch(Exception ex)
        {
            Log.Error(ex.ToString());
        }
    }
    #endregion
}