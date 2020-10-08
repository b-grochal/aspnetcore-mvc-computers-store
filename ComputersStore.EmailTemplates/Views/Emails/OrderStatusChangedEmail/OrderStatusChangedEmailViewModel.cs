using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailTemplates.Views.Emails.OrderStatusChangedEmail
{
    public class OrderStatusChangedEmailViewModel
    {
        public OrderStatusChangedEmailViewModel(string customerFirstName, int orderId, string newOrderStatusName)
        {
            this.CustomerFirstName = customerFirstName;
            this.OrderId = orderId;
            this.NewOrderStatusName = newOrderStatusName;
        }
        public string CustomerFirstName { get; set; }
        public int OrderId { get; set; }
        public string NewOrderStatusName { get; set; }
    }
}
