using ComputersStore.Models.ViewModels.Order.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Order.Complex
{
    public class OrdersCollectionViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
