using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Order.Base
{
    public class OrderEditFormViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int OrderStatusId { get; set; }

        [Required]
        [Display(Name = "Payment type")]
        public int PaymentTypeId { get; set; }

        [Required]
        [Display(Name = "Creation date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

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

        [Display(Name = "Customer")]
        public string ApplicationUserEmail { get; set; }
    }
}
