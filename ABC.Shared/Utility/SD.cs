﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Shared.Utility
{
	public static class SD
	{
		//Roles
		public const string Role_Customer = "Customer";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
        public const string Role_Manager = "Manager";

        //Shipment Status
        public const string StatusPending = "Pending";
		public const string StatusApproved = "Approved";
		public const string StatusProcessing = "Processing";
		public const string StatusShipped = "Out for Delivery";
		public const string StatusCompleted = "Completed";

		public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        //Purchase Order status
        public const string PO_Pending = "Pending";
        public const string PO_Rejected = "Rejected";
        public const string PO_Completed = "Completed";

		//Transfer status
		public const string StatusTransferPending = "Pending";
		public const string StatusTransferRejected = "Rejected";
		public const string StatusTransferCompleted = "Completed";

		//Payment Status
		public const string PaymentStatusPending = "Pending"; //default 
		public const string PaymentStatusApproved = "Paid";

        //Payment Mode
        public const string PaymentModeCash = "Cash";
        public const string PaymentModeBank = "Bank Transfer";
        public const string PaymentModeCOD = "COD";

        public const string SessionCart = "SessionShoppingCart";

		//product status
		public const string InStock = "In Stock";
		public const string LowStock = "Low Stock";
		public const string OutOfStock = "Out of stock";
	}
}
