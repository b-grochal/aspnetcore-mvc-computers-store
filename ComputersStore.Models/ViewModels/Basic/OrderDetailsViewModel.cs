using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Basic
{
    public class OrderDetailsViewModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public ApplicationUserViewModel ApplicationUserViewModel {get; set;}
        public virtual IEnumerable<OrderItemViewModel> OrderItemsViewModel { get; set; }
    }
}
