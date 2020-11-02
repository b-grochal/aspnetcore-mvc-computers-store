using ComputersStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specifc
{
    public class PowerSupplyUnitViewModel : ProductViewModel
    {
        public string Size { get; set; }
        public string Wattage { get; set; }
    }
}
