using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
			var result = context.Set<Product>().Include(x => x.StockPerStore).FirstOrDefault(x => x.Id == id);
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
	#endregion

	#region CATEGORIES CRUD
	//* GETS ALL CATEGORIES
	public async Task<List<Category>> GetCategoriesListData(dynamic DBContext)
	{
		List<Category> _category = [];
		try
		{
			var context = DBContext;
			var categoriesList = context.Categories;
			foreach (var item in categoriesList)
			{
				_category.Add(item);
			}
			return _category;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return _category;
		}
	}

	//* GETS SINGLE CATEGORY BASE ON ID 
	private async Task<Category> GetCategoryData(dynamic DBContext, int id)
	{
		Category _category = new();
		try
		{
			var context = DBContext;
			var result = context.Categories.Find(id);
			if (result is not null)
			{
				_category = result;
			}
			return _category;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return _category;
		}
	}

	private async Task<bool> UpdateStockPerStore(DbContext DBContext, StockPerStore stockPerStore, string employeeName)
	{
		bool updatedStockPerStore = false;
		try
		{
			var stores = DBContext.Set<Store>();
			DBContext.Set<StockPerStore>().Update(stockPerStore);
			DBContext.ChangeTracker.DetectChanges();
			var test = DBContext.ChangeTracker.DebugView.LongView;
			var modifiedEntities = DBContext.ChangeTracker.Entries()
				.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
				.ToList();

			Console.WriteLine(DBContext.ChangeTracker.DebugView.LongView);

            StockTransferAudit audit = new()
            {
				Action = AuditActions.TransferStock,
                EmployeeName = employeeName,
                Timestamp = DateTime.UtcNow.ToLocalTime(),

				StockPerStoreId = stockPerStore.Id,
            };

            foreach (var entry in DBContext.ChangeTracker.Entries())
			{
				if (entry.State == EntityState.Modified)
				{
					var originalValues = entry.OriginalValues;
					var currentValues = entry.CurrentValues;

					// Iterate through the properties to find modified ones
					foreach (var property in originalValues.Properties)
					{
						var originalValue = originalValues[property];
						var currentValue = currentValues[property];


						// Check if the value of the property has changed
						if (!Equals(originalValue, currentValue))
						{
							var propertyName = property.Name;
							int storeId = Equals("Store1StockQty") ? 1 : 2;
							var entityType = entry.Entity.GetType().Name;

							if (Convert.ToInt32(originalValue) > Convert.ToInt32(currentValue))
							{
								audit.TransferredStocks = Convert.ToInt32(originalValue) - Convert.ToInt32(currentValue);
								audit.StoreAssetFrom = stores.FirstOrDefault(x => x.Id == storeId)!;
								audit.StoreAssetTo = stores.FirstOrDefault(x => x.Id != storeId)!;
								break;
							}
						}
					}
				}
			}

			var result = await DBContext.SaveChangesAsync() > 0;
			audit.IsSuccess = result;
			audit.Failed = !result;

			await audit.CreateProductTransferAudit(employeeName, result, audit, DBContext);
			return updatedStockPerStore = result;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return updatedStockPerStore;
		}
	}
	#endregion
}