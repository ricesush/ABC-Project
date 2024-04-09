using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace ABC.Shared.Models
{
    public interface INotification
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool Failed { get; set; }

    }

    public class AddProductNotice : INotification
    {
        public string Status { get; set; } = String.Empty;
        public string Message { get; set; } = String.Empty;
        public bool IsSuccess { get; set; } = false;
        public bool Failed { get; set; } = false;
    }

    public static class AddProductMessage
    {
        public const string Success = "Successfully added the product.";

        public const string Failed = "Failed to add the product";
    }
    


    public static class NotificationBuilder
    {
        public static AddProductNotice BuildAddProductNotice(this bool isSuccess)
        {
            AddProductNotice baseNotification = new();
            try
            {
                baseNotification.IsSuccess = isSuccess;
                baseNotification.Failed = !isSuccess;
                baseNotification.Message = isSuccess ? AddProductMessage.Success : AddProductMessage.Failed;
                return baseNotification;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                baseNotification.Failed = true;
                baseNotification.Message = AddProductMessage.Failed;
                return baseNotification;
            }
        }
    }

}

