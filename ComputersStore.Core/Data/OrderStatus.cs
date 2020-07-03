using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Core.Data
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

}
