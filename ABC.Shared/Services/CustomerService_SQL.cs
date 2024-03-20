using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;

namespace ABC.Shared.Services;

public partial class CustomerService_SQL
{
	#region CUSTOMERS CRUD
	//* GET ALL CUSTOMERS
	private async Task<List<Customer>> GetCustomersListData(dynamic DBContext)
	{
		List<Customer> _customer = [];
		try
		{
			var context = DBContext;
			var customerList = context.Customers;
			foreach (var item in customerList)
			{
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

    //* GETS SINGLE Customer BASE ON customer ID
    private async Task<Customer> GetCustomerData(dynamic DBContext, Guid id)
    {
        Customer _customer = new();
        try
        {
            var context = DBContext;
            var result = context.Customers.Find(id);
            if (result is not null)
            {
                _customer = result;
            }
            return _customer;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return _customer;
        }
    }

    //* UPDATE CUSTOMER ON DB
    private async Task<bool> UpdateCustomerData(dynamic DBContext, Customer customer)
    {
        try
        {
            var context = DBContext;
            context.Customers.Update(customer);
            var result = context.SaveChanges();
            return result > 0 ? true : false;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return false;
        }
    }

    //* REMOVE/ARCHIVE CUSTOMER FROM DB
    private async Task<bool> RemoveCustomerData(dynamic DBContext, Customer customer)
    {
        try
        {
            var context = DBContext;
            context.Customers.Update(customer);
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