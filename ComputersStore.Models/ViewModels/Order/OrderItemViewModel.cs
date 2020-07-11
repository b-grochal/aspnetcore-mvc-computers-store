using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Order
{
    public class OrderItemViewModel
    {
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
