using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Shared.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }

        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser? ApplicationUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new();

        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public double OrderTotal { get; set; }

        public string? OrderStatus { get; set; }
        public string? PaymentStatus {  get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }
        public decimal Discount { get; set; } = 0;
        public decimal ServiceFee { get; set; } = 0;
        public decimal DeliveryFee { get; set; } = 0;
        public string? PaymentMode { get; set; }
        public string? OfficialReceipt { get; set; }
        public Guid? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [ValidateNever]

        [DisplayName("Customer")]
        public Customer? Customer { get; set; }

        public string StoreName { get; set; }
    }

    public class Discount
    {
        public string DiscountType { get; set; } = string.Empty;
        public double DiscountAmount { get; set; } = 0;
        public double TotalDiscount { get; set; } = 0;
        public double DiscountedPrice { get; set; } = 0;
    }

    public class DiscountModel
    {
        public string Percent { get; set; } = "percent";
        public string Amount { get; set; } = "amount"; 
    }
}
