using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.Motherboard
{
    public class MotherboardCreateFormViewModel : ProductCreateFormViewModel
    {
        [Required]
        [Display(Name = "Size")]
        public string FormFactor { get; set; }

        [Required]
        [Display(Name = "Socket")]
        public string CpuSocket { get; set; }

        [Required]
        [Display(Name = "Chipset")]
        public string Chipset { get; set; }

        [Required]
        [Display(Name = "Memory type")]
        public string MemoryType { get; set; }

        [Required]
        [Display(Name = "Memory channel")]
        public string MemoryChannel { get; set; }

        [Required]
        [Display(Name = "SATA support")]
        public string SataSupport { get; set; }
    }
}
