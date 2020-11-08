using ComputersStore.Models.SearchParams.Order;
using ComputersStore.Models.ViewModels.Order.Base;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Order.Complex
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public OrdersTableSearchParams ordersTableSearchCriteria {get; set;}
    }
}
