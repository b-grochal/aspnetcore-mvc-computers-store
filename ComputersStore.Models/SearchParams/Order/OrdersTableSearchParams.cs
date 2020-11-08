using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.SearchParams.Order
{
    public class OrdersTableSearchParams
    {
        public int? OrderId { get; set; }
        public int? OrderStatusId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
