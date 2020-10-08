using ComputersStore.Models.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailTemplates.Views.Emails.NewOrderConfirmationEmail
{
    public class NewOrderConfirmationEmailViewModel
    {
        public NewOrderConfirmationEmailViewModel(string customerFirstName, int orderId)
        {
            this.CustomerFirstName = customerFirstName;
            this.OrderId = orderId;
        }

        public string CustomerFirstName { get; set; }
        public int OrderId { get; set; }
    }
}
