using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;

namespace ABC.Shared.Services;

public partial class AuditService_SQL
{
    #region Audit CRUD
    //* GET ALL Audit
    private async Task<List<AuditLog>> GetAuditsListData(dynamic DBContext)
    {
        List<AuditLog> _auditList = [];
        try
        {
            var context = DBContext;
            var auditList = context.AuditLogs;
            foreach (var item in auditList)
            {
                _auditList.Add(item);
            }
            return _auditList;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return _auditList;
        }
    }

    //* GETS SINGLE Audit BASE ON Audit ID
    private async Task<AuditLog> GetAuditData(dynamic DBContext, int id)
    {
        AuditLog _audit = new();
        try
        {
            var context = DBContext;
            var result = context.AuditLogs.Find(id);
            if (result is not null)
            {
                _audit = result;
            }
            return _audit;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return _audit;
        }
    }

    //* ADDS Audit TO DB
    private async Task<bool> AddAuditData(dynamic DBContext, AuditLog auditLog)
    {
        try
        {
            var context = DBContext;
            context.AuditLogs.Add(auditLog);
            var result = context.SaveChanges();
            return result > 0 ? true : false;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return false;
        }
    }

    //* UPDATE Audit ON DB
    private async Task<bool> UpdateAuditData(dynamic DBContext, AuditLog auditLog)
    {
        try
        {
            var context = DBContext;
            context.AuditLogs.Update(auditLog);
            var result = context.SaveChanges();
            return result > 0 ? true : false;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return false;
        }
    }

    //* REMOVE/ARCHIVE Audit FROM DB
    private async Task<bool> RemoveAuditData(dynamic DBContext, AuditLog auditLog)
    {
        try
        {
            var context = DBContext;
            context.Auditlogs.Update(auditLog);
            var result = context.SaveChanges();
            return result > 0 ? true : false;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return false;
        }
    }
    #endregion
}