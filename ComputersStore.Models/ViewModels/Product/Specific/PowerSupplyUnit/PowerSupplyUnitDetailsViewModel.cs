using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.PowerSupplyUnit
{
    public class PowerSupplyUnitDetailsViewModel : ProductDetailsViewModel
    {
        [Display(Name="Size")]
        public string Size { get; set; }

        [Display(Name = "Wattage")]
        public string Wattage { get; set; }
    }
}
