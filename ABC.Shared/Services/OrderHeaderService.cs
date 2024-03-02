using System;
using Serilog;
using ABC.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ABC.Shared.Services;
public partial class OrderHeaderService_SQL : ComponentBase
{
	#region DICTIONARIES 
	#endregion

	#region FIELDS
	public String AbcDbConnection { get; set; } = String.Empty;


	#endregion

	#region ORDERHEADER CRUD

	//Get List of OrderHeaders
	public async Task<List<OrderHeader>> GetOrdersList(dynamic DBContext)
	{
		List<OrderHeader> OrdersList = [];
		try
		{
			OrdersList = await GetOrdersListData(DBContext);
			return OrdersList;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return OrdersList;
		}
	}

	//Get Single OrderHeader from the list of OrderHeaders
	public async Task<OrderHeader> GetOrderHeader(dynamic DBContext, int orderId)
	{
		OrderHeader OrderHeader = new();
		try
		{
			OrderHeader = await GetOrderHeaderData(DBContext, orderId);
			return OrderHeader;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return OrderHeader;
		}
	}

	//Collection of OrderDetails based on OrderHeader id
	public async Task<List<OrderDetail>> GetOrderDetailsList(dynamic DBContext)
	{
		List<OrderDetail> OrderDetailsList = [];
		try
		{
			OrderDetailsList = await GetOrdersListData(DBContext);
			return OrderDetailsList;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return OrderDetailsList;
		}
	}

	//GET SINGLE Order detail based on product id from the list of OrderDetails
	public async Task<OrderDetail> GetOrderDetail(dynamic DBContext, int productId)
	{
		OrderDetail _OrderDetail = new();
		try
		{
			_OrderDetail = await GetOrderHeaderData(DBContext, productId);
			return _OrderDetail;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return _OrderDetail;
		}
	}

	//ADD OrderHeader
	public async Task<bool> AddOrderHeader(dynamic DBContext, OrderHeader order)
	{
		bool added = false;
		try
		{
			added = await AddOrderHeaderData(DBContext, order);
			return added;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return added;
		}
	}

	// UPDATE Order
	public async Task<bool> UpdateOrderHeaderStatus(dynamic DBContext, OrderHeader order)
	{
		bool updated = false;
		try
		{
			updated = await UpdateOrderHeaderStatusData(DBContext, order);
			return updated;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return updated;
		}
	}

	#endregion
}