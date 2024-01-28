﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ABC.Shared.Models
{
    public class ShoppingCart
    {
        public int Id {  get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }

        [Range(1,100, ErrorMessage = "Please Enter a value between 1 and 20")]
        public int Count { get; set; }


        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

		public double? Charge { get; set; }
		public double? Discount { get; set; }

		[NotMapped]
        public double Price { get; set; }
    }
}
