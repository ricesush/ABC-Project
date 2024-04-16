using System;
using Serilog;
using ABC.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ABC.Shared.Services;
public partial class AuditService_SQL : ComponentBase
{

    #region FIELDS
    public String AbcDbConnection { get; set; } = String.Empty;
    #endregion

    #region Audit CRUD
    public async Task<AuditLog> GetAuditInfo(dynamic DBContext, int Id)
    {
        AuditLog AuditInfo = new();
        try
        {
            AuditInfo = await GetAuditData(DBContext, Id);
            return AuditInfo;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return AuditInfo;
        }
    }

    public async Task<List<AuditLog>> GetAuditList(dynamic DBContext)
    {
        List<AuditLog> AuditList = [];
        try
        {
            AuditList = await GetAuditsListData(DBContext);
            return AuditList;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return AuditList;
        }
    }

    public async Task<bool> AddAudit(dynamic DBContext, AuditLog auditLog)
    {
        bool added = false;
        try
        {
            added = await AddAuditData(DBContext, auditLog);
            return added;
        }
        catch(Exception ex)
        {
            Log.Error(ex.ToString());
            return added;
        }
    }

    public async Task<bool> AddStockTransferAudit(dynamic DBContext, StockTransferAudit audit)
    {
        bool added = false;
        try
        {
            added = await AddStockTransferAuditData(DBContext, audit);
            return added;
        }
        catch(Exception ex)
        {
            Log.Error(ex.ToString());
            return added;
        }
    }

    #endregion
}