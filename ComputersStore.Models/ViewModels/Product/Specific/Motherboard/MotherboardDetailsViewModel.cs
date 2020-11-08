using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.HardDiskDrive
{
    public class MotherboardDetailsViewModel : ProductDetailsViewModel
    {
        [Display(Name = "Size")]
        public string FormFactor { get; set; }

        [Display(Name = "Socket")]
        public string CpuSocket { get; set; }

        [Display(Name = "Chipset")]
        public string Chipset { get; set; }

        [Display(Name = "Memory type")]
        public string MemoryType { get; set; }

        [Display(Name = "Memory channel")]
        public string MemoryChannel { get; set; }

        [Display(Name = "SATA support")]
        public string SataSupport { get; set; }
    }
}
