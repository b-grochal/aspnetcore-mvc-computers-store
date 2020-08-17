using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.ShoppingCart
{
    public class ShoppingCartItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
