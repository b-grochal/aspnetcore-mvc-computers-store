using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.SearchCriteria
{
    public class OrdersTableSearchCriteria
    {
        public int? OrderId { get; set; }
        public int? OrderStatusId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
