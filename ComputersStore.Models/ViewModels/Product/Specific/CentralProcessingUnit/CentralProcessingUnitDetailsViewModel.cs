using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific
{
    public class CentralProcessingUnitDetailsViewModel : ProductDetailsViewModel
    {
        [Display(Name="Cores")]
        public int NumberOfCores { get; set; }

        [Display(Name="Threads")]
        public int NumberOfThreads { get; set; }

        [Display(Name="Clock speed")]
        public string ClockSpeed { get; set; }

        [Display(Name="TDP")]
        public string TDP { get; set; }

        [Display(Name="Socket")]
        public string Socket { get; set; }

        [Display(Name="Architecture")]
        public string Architecture { get; set; }

        [Display(Name="Manufacturing process")]
        public string ManufacturingProcess { get; set; }
    }
}
