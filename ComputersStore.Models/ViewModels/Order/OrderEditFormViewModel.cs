using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Order
{
    public class OrderEditFormViewModel
    {
        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
