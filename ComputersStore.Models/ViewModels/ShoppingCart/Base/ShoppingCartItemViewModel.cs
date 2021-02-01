using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.ShoppingCart.Base
{
    public class ShoppingCartItemViewModel
    {
        [Display(Name = "Id")]
        public int ProductId { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; }
        
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
