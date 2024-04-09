using System;
using Serilog;
using ABC.Shared.Models;
using Microsoft.AspNetCore.Components;
using ABC.Shared.Utility;

namespace ABC.Shared.Services;
public partial class StockTransferService_SQL : ComponentBase
{

    #region FIELDS
    public String AbcDbConnection { get; set; } = String.Empty;
    #endregion

    #region StockTransfer CRUD
    public async Task<StockTransfer> GetStockTransferInfo(dynamic DBContext, int Id)
    {
        StockTransfer StockTransferInfo = new();
        try
        {
            StockTransferInfo = await GetStockTransferInfo(DBContext, Id);
            return StockTransferInfo;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return StockTransferInfo;
        }
    }

    public async Task<List<StockTransfer>> GetStockTransferList(dynamic DBContext)
    {
        List<StockTransfer> StockTransferList = [];
        try
        {
            StockTransferList = await GetStockTransferListData(DBContext);
            return StockTransferList;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return StockTransferList;
        }
    }

    public async Task<bool> AddstockTransfer(dynamic DBContext, StockTransfer stockTransfer)
    {
        bool added = false;
        try
        {
            added = await AddStockTransferData(DBContext, stockTransfer);
            return added;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return added;
        }
    }

    public async Task<bool> UpdateStockTransfer(dynamic DBContext, StockTransfer stockTransfer, ProductService_SQL productService_SQL)
    {
        bool updated = false;
        try
        {
            if (stockTransfer.Status != SD.PO_Rejected)
            {
                foreach (var product in stockTransfer.StockTransferItems)
                {
                    var result2 = await productService_SQL.GetProductInfo(DBContext, product.ProductId);
                    result2.StockQuantity += product.Quantity;
                    await productService_SQL.UpdateProduct(DBContext, result2);
                }
                updated = await UpdateStockTransferData(DBContext, stockTransfer);
                return updated;
            }
            else
            {
                updated = await UpdateStockTransferData(DBContext, stockTransfer);
                return updated;
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return updated;
        }
    }

    #endregion
}