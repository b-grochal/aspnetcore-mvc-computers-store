using ComputersStore.Models.ViewModels.ShoppingCart.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ComputersStore.Models.ViewModels.ShoppingCart.Complex
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartItemViewModel> shoppingCartItems { get; set; }

        [DataType(DataType.Currency)]
        public decimal ShoppingCartTotalCost 
        {   get
            {
                return shoppingCartItems.Sum(x => x.ProductPrice * x.Quantity);
            }
        }
    }
}
