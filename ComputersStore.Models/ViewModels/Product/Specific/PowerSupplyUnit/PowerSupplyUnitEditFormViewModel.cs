using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.PowerSupplyUnit
{
    public class PowerSupplyUnitEditFormViewModel : ProductEditFormViewModel
    {
        [Required]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Wattage")]
        public string Wattage { get; set; }
    }
}
