using System;
using Serilog;
using ABC.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ABC.Shared.Services;
public partial class PurchaseOrderService_SQL : ComponentBase
{

    #region FIELDS
    public String AbcDbConnection { get; set; } = String.Empty;
    #endregion

    #region PurchaseOrders CRUD
    public async Task<PurchaseOrder> GetPurchaseOrderInfo(dynamic DBContext, int Id)
    {
        PurchaseOrder PurchaseOrderInfo = new();
        try
        {
            PurchaseOrderInfo = await GetPurchaseOrderData(DBContext, Id);
            return PurchaseOrderInfo;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return PurchaseOrderInfo;
        }
    }

    public async Task<List<PurchaseOrder>> GetPurchaseOrderList(dynamic DBContext)
    {
        List<PurchaseOrder> PurchaseOrderList = [];
        try
        {
            PurchaseOrderList = await GetPurchaseOrderList(DBContext);
            return PurchaseOrderList;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return PurchaseOrderList;
        }
    }

    public async Task<bool> AddPurchaseOrder(dynamic DBContext, PurchaseOrder purchaseOrder)
    {
        bool added = false;
        try
        {
            added = await AddPurchaseOrderData(DBContext, purchaseOrder);
            return added;
        }
        catch(Exception ex)
        {
            Log.Error(ex.ToString());
            return added;
        }
    }

    // UPDATE PRODUCT
    public async Task<bool> UpdatePurchaseOrder(dynamic DBContext, PurchaseOrder purchaseOrder)
    {
        bool updated = false;
        try
        {
            updated = await UpdatePurchaseOrderData(DBContext, purchaseOrder);
            return updated;
        }
        catch(Exception ex)
        {
            Log.Error(ex.ToString());
            return updated;
        }
    }

    // REMOVE PRODUCT
    public async Task<bool> RemovePurchaseOrder(dynamic DBContext, PurchaseOrder purchaseOrder)
    {
        bool removed = false;
        try
        {
            removed = await RemovePurchaseOrder(DBContext, purchaseOrder);
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