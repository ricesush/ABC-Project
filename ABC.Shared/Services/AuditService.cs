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

    // UPDATE PRODUCT
    public async Task<bool> UpdateAudit(dynamic DBContext, AuditLog auditLog)
    {
        bool updated = false;
        try
        {
            updated = await UpdateAuditData(DBContext, auditLog);
            return updated;
        }
        catch(Exception ex)
        {
            Log.Error(ex.ToString());
            return updated;
        }
    }

    // REMOVE PRODUCT
    public async Task<bool> RemoveAudit(dynamic DBContext, AuditLog auditLog)
    {
        bool removed = false;
        try
        {
            removed = await RemoveAuditData(DBContext, auditLog);
            return removed;
        }
        catch(Exception ex)
        {
            Log.Error(ex.ToString());
            return removed;
        }
    }

    #endregion
}