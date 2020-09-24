using ComputersStore.Models.SearchCriteria;
using ComputersStore.Models.ViewModels.Order;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Order
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public OrdersTableSearchCriteria ordersTableSearchCriteria {get; set;}
    }
}
