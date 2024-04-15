using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;

namespace ABC.Shared.Services;

public partial class ProductService_SQL
{
	#region PRODUCTS CRUD
	//* GET ALL PRODUCTS
	private async Task<List<Product>> GetProductsListData(dynamic DBContext)
	{
		List<Product> _product = [];
		try
		{
			var context = DBContext;
			var productList = context.Products;
			IEnumerable<StockPerStore> stockPerStore = context.StockPerStores;
			foreach (var item in productList)
			{
				_product.Add(item);
				item.StockPerStore = stockPerStore.FirstOrDefault(s => s.ProductId == item.Id);
			}
			return _product;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return _product;
		}
	}

	//* GETS SINGLE PRODUCT BASE ON PRODUCT ID
	private async Task<Product> GetProductData(DbContext DBContext, int id)
	{
		Product _product = new();
		try
		{
			var context = DBContext;
			var result = context.Set<Product>().Include(x => x.StockPerStore).FirstOrDefault( x => x.Id == id);
			if (result is not null)
			{
				_product = result;
			}
			return _product;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return _product;
		}
	}

	//* ADDS PRODUCT TO DB
	private async Task<bool> AddProductData(dynamic DBContext, Product product, StockPerStore stockPerStore)
	{
		try
		{
			var context = DBContext;
			context.Products.Add(product);
			var result = context.SaveChanges();
			
			stockPerStore.Product = product;
			context.StockPerStores.Add(stockPerStore);
			var result2 = context.SaveChanges();

			return result > 0 ? true : false;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return false;
		}
	}

	//* UPDATE PRODUCT ON DB
	private async Task<bool> UpdateProductData(dynamic DBContext, Product product)
	{
		try
		{
			var context = DBContext;
			context.Products.Update(product);
			var result = context.SaveChanges();
			return result > 0 ? true : false;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return false;
		}
	}

	//* REMOVE/ARCHIVE PRODUCT FROM DB
	private async Task<bool> RemoveProductData(dynamic DBContext, Product product)
	{
		try
		{
			var context = DBContext;
			context.Products.Remove(product);
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

    private async Task<bool> UpdateStockPerStoreData(DbContext DBContext, StockPerStore stockPerStore)
    {
        bool updatedStockPerStore = false;
        try
        {
			stockPerStore.TotalStocks = stockPerStore.Store1StockQty + stockPerStore.Store2StockQty;
            DBContext.Set<StockPerStore>().Update(stockPerStore);
            var result = await DBContext.SaveChangesAsync();
            return updatedStockPerStore = result > 0;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return updatedStockPerStore;
        }
    }

    //* GETS SINGLE StockperStore BASE ON PRODUCT ID
    private async Task<StockPerStore> GetStockperStoreInfoData(DbContext DBContext, int id)
    {
        StockPerStore _stockPerStore = new();
        try
        {
            var context = DBContext;
            var result = context.Set<StockPerStore>().FirstOrDefault(x => x.Id == id);
            if (result is not null)
            {
                _stockPerStore = result;
            }
            return _stockPerStore;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return _stockPerStore;
        }
    }
}