using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;

namespace ABC.Shared.Services;

public partial class POSService_SQL
{ 
    #region BATCH FETCH OF MARKET DATA: SECURITY INFORMATION AND SECURITY QUOTATION
    private async Task<bool> AddCustomerData(dynamic DBContext, Customer customer)
    {
        try
        {
            using var context = DBContext;
            context.Customers.Add(customer);
            var result = context.SaveChanges();
            return result > 0 ? true: false;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return false;          
        }
    }


    private async Task<List<Customer>> GetCustomerListData(dynamic DBContext)
    {
        List<Customer> _customer = [];
        try
        {
            using var context = DBContext;
            var customerList = context.Customers;
            foreach(var item in customerList){
                _customer.Add(item);
            }
            return _customer;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return _customer;          
        }
    }
    #endregion
}