using ComputersStore.Models.ViewModels.ApplicationUser.Base;
using System.Collections.Generic;

namespace ComputersStore.Models.ViewModels.Order.Base
{
    public class OrderDetailsViewModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public ApplicationUserViewModel ApplicationUserViewModel {get; set;}
        public virtual IEnumerable<OrderItemViewModel> OrderItemsViewModel { get; set; }
    }
}
