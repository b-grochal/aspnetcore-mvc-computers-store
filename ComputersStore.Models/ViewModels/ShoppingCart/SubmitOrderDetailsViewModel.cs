using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.ShoppingCart
{
    public class SubmitOrderDetailsViewModel
    {
        public int PaymentTypeId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }
}
