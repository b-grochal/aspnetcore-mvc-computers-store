using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.ShoppingCart
{
    public class SubmitOrderDetailsViewModel
    {
        [Required]
        [Display(Name = "Payment type")]
        public int PaymentTypeId { get; set; }
        
        [Required]
        [Display(Name = "Address")]
        public string ShipAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string ShipCity { get; set; }
        
        [Required]
        [Display(Name = "Postal code")]
        public string ShipPostalCode { get; set; }
        
        [Required]
        [Display(Name = "Country")]
        public string ShipCountry { get; set; }
    }
}
