using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Order.Base
{
    public class OrderViewModel
    {
        [Display(Name = "Id")]
        public int OrderId { get; set; }

        [Display(Name = "Creation date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        
        [Display(Name = "Address")]
        public string ShipAddress { get; set; }

        [Display(Name = "City")]
        public string ShipCity { get; set; }
        
        [Display(Name = "Postal code")]
        public string ShipPostalCode { get; set; }

        [Display(Name = "Country")]
        public string ShipCountry { get; set; }
        
        [Display(Name = "Status")]
        public string OrderStatusName { get; set; }
        
        [Display(Name = "Payment type")]
        public string PaymentTypeName { get; set; }
        
        [Display(Name = "Customer")]
        public string ApplicationUserEmail { get; set; }
    }
}
