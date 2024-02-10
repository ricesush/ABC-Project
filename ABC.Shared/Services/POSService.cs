using System;
using Serilog;
using ABC.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ABC.Shared.Services;
public partial class POSService_SQL : ComponentBase
{
    #region DICTIONARIES 
    #endregion

    #region FIELDS
    public String AbcDbConnection { get; set; } = String.Empty;

    
    #endregion

    #region QUERY RUNNERS/CALLERS

    public async Task<List<Customer>> GetCustomerList(dynamic DBContext){
        List<Customer> CustomerList = [];
        try
        {
            CustomerList = await GetCustomerListData(DBContext);
            return CustomerList;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return CustomerList;
        }
    }

    public async Task<Customer> GetCustomerInfo(dynamic DBContext, string Id){
        Customer CustomerInfo = new();
        try
        {
            CustomerInfo = await GetCustomerData(DBContext, Id);
            return CustomerInfo;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return CustomerInfo;
        }
    }

    public async Task<Product> GetProductInfo(dynamic DBContext, int Id){
        Product ProductInfo = new();
        try
        {
            ProductInfo = await GetProductData(DBContext, Id);
            return ProductInfo;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return ProductInfo;
        }
    }


    public async Task<List<Product>> GetProductList(dynamic DBContext){
        List<Product> ProductList = [];
        try
        {
            ProductList = await GetProductsListData(DBContext);
            return ProductList;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return ProductList;
        }
    }


    public async Task<bool> AddCustomer(dynamic DBContext, Customer customer)
    {
        bool HasAdded = false;
        try
        {
            bool customerList = await AddCustomerData(DBContext, customer);
            return HasAdded;
        }
        catch(Exception ex)
        {
            Log.Error(ex.ToString());
            return HasAdded;
        }
    }
    #endregion
}