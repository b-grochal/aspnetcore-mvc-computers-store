﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.PowerSupplyUnit
{
    public class PowerSupplyUnitCreateFormViewModel : ProductCreateFormViewModel
    {
        public string Size { get; set; }
        public string Wattage { get; set; }
    }
}