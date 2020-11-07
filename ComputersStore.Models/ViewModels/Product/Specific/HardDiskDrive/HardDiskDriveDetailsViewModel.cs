using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific
{
    public class HardDiskDriveDetailsViewModel : ProductDetailsViewModel
    {
        [Display(Name="Capacity")]
        public string Capacity { get; set; }

        [Display(Name = "Rotation speed")]
        public string RotationSpeed { get; set; }

        [Display(Name = "Cache size")]
        public string CacheSize { get; set; }

        [Display(Name = "Interface")]
        public string Interface { get; set; }
    }
}
