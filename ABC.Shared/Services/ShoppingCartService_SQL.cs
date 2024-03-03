using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;

namespace ABC.Shared.Services;

public partial class ShoppingCartService_SQL
{

	#region SHOPPING CRUD
	//* GETS ALL SHOPPING CART LIST
	public async Task<List<ShoppingCart>> GetShoppingCartListData(dynamic DBContext, string userId)
	{
		List<ShoppingCart> _shoppingcart = [];
		try
		{
			List<Product> _product = [];
			var context = DBContext;
			var shoppingCartList = context.ShoppingCarts;
			var products = context.Products;
			foreach (var product in products)
			{
				_product.Add(product);
			}
			foreach (var cartItem in shoppingCartList)
			{
				ShoppingCart item = cartItem;
				item.Product = _product.FirstOrDefault(p => p.Id == cartItem.ProductId);
				_shoppingcart.Add(item);
			}
			return _shoppingcart;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return _shoppingcart;
		}
	}

	//* GETS SINGLE CART ITEM BASE ON ID 
	private async Task<ShoppingCart> GetShoppingCartData(dynamic DBContext, int id)
	{
		ShoppingCart _shoppingcart = new();
		try
		{
			var context = DBContext;
			var result = context.ShoppingCarts.Find(id);
			if (result is not null)
			{
				_shoppingcart = result;
			}
			return _shoppingcart;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return _shoppingcart;
		}
	}

	//* ADDS shopping Cart TO DB
	private async Task<bool> AddShoppingCartData(dynamic DBContext, ShoppingCart shoppingCart)
	{
		try
		{
			var context = DBContext;
			context.ShoppingCarts.Add(shoppingCart);
			var result = context.SaveChanges();
			return result > 0 ? true : false;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return false;
		}
	}

	//* UPDATE Shopping Cart ON DB
	private async Task<bool> UpdateShoppingCartData(dynamic DBContext, ShoppingCart shoppingCart)
	{
		try
		{
			var context = DBContext;
			context.ShoppingCarts.Update(shoppingCart);
			var result = context.SaveChanges();
			return result > 0 ? true : false;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return false;
		}
	}

	//* REMOVE/ARCHIVE Shopping Cart FROM DB
	private async Task<bool> RemoveShoppingCartData(dynamic DBContext, ShoppingCart shoppingCart)
	{
		try
		{
			var context = DBContext;
			context.ShoppingCarts.Remove(shoppingCart);
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