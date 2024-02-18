using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;

namespace ABC.Shared.Services;

public partial class ProductService_SQL
{ 
    
    #region
    private async Task<List<Product>> GetProductsListData(dynamic DBContext)
    {
        List<Product> product = [];
        try
        {
            var context = DBContext;
            var productList = context.Products;
            foreach(var item in productList){
                product.Add(item);
            }
            return product;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return product;          
        }
    }

    private async Task<Product> GetProductData(dynamic DBContext, int id)
    {
		Product product = new();
        try
        {
            var context = DBContext;
            var result = context.Products.Find(id);
            if(result is not null){
                product = result;
            }
            return product;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return product;          
        }
    }

	private async Task<List<Product>> GetSortedProductsListData(dynamic DBContext, int categoryId)
	{
		List<Product> sortedproducts = [];
		try
		{
			var context = DBContext;
			var result = context.Product.Find(categoryId);
			if (result is not null)
			{
				sortedproducts = result;
			}
			return sortedproducts;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return sortedproducts;
		}

	}

	public async Task<List<Category>> GetCategoriesListData(dynamic DBContext)
    {
        List<Category> category = [];
        try
        {
            var context = DBContext;
            var categoriesList = context.Categories;
            foreach(var item in categoriesList){
				category.Add(item);
            }
            return category;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return category;          
        }
    }

    private async Task<Category> GetCategoryData(dynamic DBContext, int id)
    {
		Category category = new();
        try
        {
            var context = DBContext;
            var result = context.Categories.Find(id);
            if(result is not null){
				category = result;
            }
            return category;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return category;          
        }
    }
    
    #endregion
}