using ComputersStore.Models.ViewModels.Order.Base;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Order.Complex
{
    public class OrdersFilteredCollectionViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public int? OrderId { get; set; }
        public int? OrderStatusId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
