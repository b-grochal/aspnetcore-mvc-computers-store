using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Core.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
