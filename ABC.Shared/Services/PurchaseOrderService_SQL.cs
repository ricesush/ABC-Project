using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;

namespace ABC.Shared.Services;

public partial class PurchaseOrderService_SQL
{
    #region Purchase Order CRUD
    //* GET ALL PO
    private async Task<List<PurchaseOrder>> GetPurchaseOrdersListData(dynamic DBContext)
    {
        List<PurchaseOrder> _purchaseOrdersList = [];
        try
        {
            var context = DBContext;
            var purchaseOrdersList = context.PurchaseOrders;
            foreach (var item in purchaseOrdersList)
            {
                _purchaseOrdersList.Add(item);
            }
            return _purchaseOrdersList;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return _purchaseOrdersList;
        }
    }

	//* GETS SINGLE PO BASE ON PO ID
	private async Task<PurchaseOrder> GetPurchaseOrderData(dynamic DBContext, int id)
    {
        PurchaseOrder _purchaseOrder = new();
        try
        {
            var context = DBContext;
            var result = context.PurchaseOrders.Find(id);
            if (result is not null)
            {
                _purchaseOrder = result;
            }
            return _purchaseOrder;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return _purchaseOrder;
        }
    }

	//* ADDS PO TO DB
	private async Task<bool> AddPurchaseOrderData(dynamic DBContext, PurchaseOrder purchaseOrder)
    {
        try
        {
            var context = DBContext;
            if (purchaseOrder.PurchasedProducts != null)
            {
                foreach (var product in purchaseOrder.PurchasedProducts)
                {
                    context.Entry(product.Product).State = EntityState.Unchanged;
                }
            }
			if (purchaseOrder.Supplier != null)
			{
				context.Entry(purchaseOrder.Supplier).State = EntityState.Unchanged;
			}
			if (purchaseOrder.Store != null)
			{
				context.Entry(purchaseOrder.Store).State = EntityState.Unchanged;
			}
			//foreach (var product in purchaseOrder.PurchasedProducts)
			//{
			//    context.Attach(product);
			//}
			context.PurchaseOrders.Add(purchaseOrder);
            var result = context.SaveChanges();
            return result > 0 ? true : false;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return false;
        }
    }

	//* UPDATE PO ON DB
	private async Task<bool> UpdatePurchaseOrderData(dynamic DBContext, PurchaseOrder purchaseOrder)
    {
        try
        {
            var context = DBContext;
            context.PurchaseOrders.Update(purchaseOrder);
            var result = context.SaveChanges();
            return result > 0 ? true : false;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return false;
        }
    }

	//* REMOVE/ARCHIVE PO FROM DB
	private async Task<bool> RemovePurchaseOrderData(dynamic DBContext, PurchaseOrder purchaseOrder)
    {
        try
        {
            var context = DBContext;
            context.PurchaseOrders.Update(purchaseOrder);
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