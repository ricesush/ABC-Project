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
        List<Product> _product = [];
        try
        {
            var context = DBContext;
            var productList = context.Products;
            foreach(var item in productList){
                _product.Add(item);
            }
            return _product;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return _product;          
        }
    }

    private async Task<Product> GetProductData(dynamic DBContext, int id)
    {
		Product _product = new();
        try
        {
            var context = DBContext;
            var result = context.Products.Find(id);
            if(result is not null){
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

    public async Task<List<Category>> GetCategoriesListData(dynamic DBContext)
    {
        List<Category> _category = [];
        try
        {
            var context = DBContext;
            var categoriesList = context.Categories;
            foreach(var item in categoriesList){
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

    private async Task<Category> GetCategoryData(dynamic DBContext, int id)
    {
		Category _category = new();
        try
        {
            var context = DBContext;
            var result = context.Categories.Find(id);
            if(result is not null){
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
    #endregion
}