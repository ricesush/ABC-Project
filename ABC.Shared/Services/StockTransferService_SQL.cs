using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;

namespace ABC.Shared.Services;

public partial class StockTransferService_SQL
{
    #region STOCK TRANSFER CRUD
    //* GET ALL STOCK TRANSFER
    private async Task<List<StockTransfer>> GetStockTransferListData(dynamic DBContext)
	{
		List<StockTransfer> _stockTransferList = [];
		try
		{
            var context = DBContext;
			var stockTransferList = context.StockTransfers;
			//IEnumerable<StockTransferItemDetails> stockTransferItems = context.StockTransferItemDetails;
			//IEnumerable<Product> products = context.Products;
			//IEnumerable<Store> stores = context.Stores;
			foreach (var item in stockTransferList)
			{
                _stockTransferList.Add(item);
			}

			//foreach (var details in _stockTransferList)
			//{
			//	List<StockTransferItemDetails> orderItems = stockTransferItems.Where(x => x.StockTransferId == details.Id).ToList();
			//	foreach (var orderItem in orderItems)
			//	{
			//		orderItem.Product = products.FirstOrDefault(p => p.Id == orderItem.ProductId);
			//	}
			//	details.StockTransferItems = orderItems;
			//	details.SourceStore = stores.FirstOrDefault(st => st.Id == details.SourceStoreId);
			//	details.DestinationStore = stores.FirstOrDefault(st => st.Id == details.DestinationStoreId);
			//}
			return _stockTransferList;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return _stockTransferList;
		}
	}

    //* GETS SINGLE StockTransfer BASE ON PO ID
    private async Task<StockTransfer> GetStockTransferData(dynamic DBContext, int id)
    {
        StockTransfer _stockTransfer = new();
        try
        {
            var context = DBContext;
            var result = context.StockTransfers.Find(id);
            if (result is not null)
            {
                _stockTransfer = result;
            }
            return _stockTransfer;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return _stockTransfer;
        }
    }

    //* ADDS StockTransfer TO DB
    private async Task<bool> AddStockTransferData(dynamic DBContext, StockTransfer stockTransfer)
    {
        try
        {
            var context = DBContext;
            if (stockTransfer.StockTransferItems != null)
            {
                foreach (var product in stockTransfer.StockTransferItems)
                {
                    context.Entry(product.Product).State = EntityState.Unchanged;
                }
            }
            //if (stockTransfer.SourceStore != null)
            //{
            //    context.Entry(stockTransfer.SourceStore).State = EntityState.Unchanged;
            //}
            context.StockTransfers.Add(stockTransfer);
            var result = context.SaveChanges();
            return result > 0 ? true : false;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return false;
        }
    }

    //* UPDATE stockTransfer ON DB
    private async Task<bool> UpdateStockTransferData(dynamic DBContext, StockTransfer stockTransfer)
    {
        try
        {
            var context = DBContext;
            context.StockTransfers.Update(stockTransfer);
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