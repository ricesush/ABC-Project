using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;

namespace ABC.Shared.Services;

public partial class ProductService_SQL
{
    #region PRODUCTS CRUD
    //* GET ALL PRODUCTS
    private async Task<List<Product>> GetProductsListData(dynamic DBContext)
    {
        List<Product> product = [];
        try
        {
            var context = DBContext;
            var productList = context.Products;
<<<<<<< HEAD
            foreach (var item in productList)
            {
                _product.Add(item);
=======
            foreach(var item in productList){
                product.Add(item);
>>>>>>> 2a06211b5c86d153e5affd11df218d201b93bc57
            }
            return product;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
<<<<<<< HEAD
            return _product;
=======
            return product;          
>>>>>>> 2a06211b5c86d153e5affd11df218d201b93bc57
        }
    }

    //* GETS SINGLE PRODUCT BASE ON PRODUCT ID
    private async Task<Product> GetProductData(dynamic DBContext, int id)
<<<<<<< HEAD
    {
        Product _product = new();
=======
    {
		Product product = new();
>>>>>>> 2a06211b5c86d153e5affd11df218d201b93bc57
        try
        {
            var context = DBContext;
            var result = context.Products.Find(id);
<<<<<<< HEAD
            if (result is not null)
            {
                _product = result;
=======
            if(result is not null){
                product = result;
>>>>>>> 2a06211b5c86d153e5affd11df218d201b93bc57
            }
            return product;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
<<<<<<< HEAD
            return _product;
        }
    }

    //* ADDS PRODUCT TO DB
    private async Task<bool> AddProductData(dynamic DBContext, Product product)
    {
        try
        {
            var context = DBContext;
            context.Products.Add(product);
            var result = context.SaveChanges();
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
=======
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
>>>>>>> 2a06211b5c86d153e5affd11df218d201b93bc57
    {
        List<Category> category = [];
        try
        {
            var context = DBContext;
            var categoriesList = context.Categories;
<<<<<<< HEAD
            foreach (var item in categoriesList)
            {
                _category.Add(item);
=======
            foreach(var item in categoriesList){
				category.Add(item);
>>>>>>> 2a06211b5c86d153e5affd11df218d201b93bc57
            }
            return category;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
<<<<<<< HEAD
            return _category;
=======
            return category;          
>>>>>>> 2a06211b5c86d153e5affd11df218d201b93bc57
        }
    }

    //* GETS SINGLE CATEGORY BASE ON ID 
    private async Task<Category> GetCategoryData(dynamic DBContext, int id)
<<<<<<< HEAD
    {
        Category _category = new();
=======
    {
		Category category = new();
>>>>>>> 2a06211b5c86d153e5affd11df218d201b93bc57
        try
        {
            var context = DBContext;
            var result = context.Categories.Find(id);
<<<<<<< HEAD
            if (result is not null)
            {
                _category = result;
=======
            if(result is not null){
				category = result;
>>>>>>> 2a06211b5c86d153e5affd11df218d201b93bc57
            }
            return category;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
<<<<<<< HEAD
            return _category;
=======
            return category;          
>>>>>>> 2a06211b5c86d153e5affd11df218d201b93bc57
        }
    }
    
    #endregion
}