using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ABC.Shared.Services;

namespace ABC.Shared.Models;
public interface IAudit
{
    public int Id { get; set; }
    public string Action { get; set; }
    public bool IsSuccess { get; set; }
    public bool Failed { get; set; }
    public string EmployeeName { get; set; }
    public DateTime Timestamp { get; set; }

}

public class ProductAudit : IAudit
{
    public int Id { get; set; } = 0;
    public string Action { get; set; } = String.Empty;
    public bool IsSuccess { get; set; } = false;
    public bool Failed { get; set; } = false;
    public string EmployeeName { get; set; } = String.Empty;
    public DateTime Timestamp { get; set; } = new();


    // ASSET SPECIFIC
    public int ProductId { get; set; } = 0;
    public Product Product { get; set; } = new();
}

public class StockTransferAudit : IAudit
{
    public int Id { get; set; } = 0;
    public string Action { get; set; } = String.Empty;
    public bool IsSuccess { get; set; } = false;
    public bool Failed { get; set; } = false;
    public string EmployeeName { get; set; } = String.Empty;
    public DateTime Timestamp { get; set; } = new();

    // STOCK TRANSFER SPECIFIC
    public int StockPerStoreId { get; set; } = 0;
    public string SourceStoreName { get; set; } = String.Empty;
    public string DescitnationStoreName { get; set; } = String.Empty;
    public int TransferredStocks { get; set; }= 0;
}

// public class AddProductNotice : INotification
// {
//     public string Status { get; set; } = String.Empty;
//     public string Message { get; set; } = String.Empty;
//     public bool IsSuccess { get; set; } = false;
//     public bool Failed { get; set; } = false;
// }

// public static class AddProductMessage
// {
//     public const string Success = "Successfully added the product.";

//     public const string Failed = "Failed to add the product";
// }

// public static class StockTransferMessage
// {
//     public const string Success = "Successfully transferred the stocks.";

//     public const string Failed = "Failed to transfer the stocks";
// }

public class AuditActions
{
    public const string TransferStock = "Stock Transfer";
    
}



public static class AuditLogBuilder
{
    public static async Task CreateProductTransferAudit(this StockTransferAudit stockPerStore, string employeeName, bool isSuccess, StockTransferAudit stockTransfer, DbContext DBContext)
    {
        try
        {
            StockTransferAudit baseAudit = stockPerStore;
            AuditService_SQL auditService = new();
            if(baseAudit is not null){
                bool hasAdded = await auditService.AddStockTransferAudit(DBContext, baseAudit);
            }
            // POSTING THE AUDIT TO STOCK TRANSFER AUDIT TABLE
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
        }
    }

    public static async Task Test(this string qwerty){
        Console.WriteLine(qwerty);
    }
}


