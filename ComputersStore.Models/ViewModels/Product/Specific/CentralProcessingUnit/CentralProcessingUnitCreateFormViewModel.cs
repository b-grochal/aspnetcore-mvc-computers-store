using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.CentralProcessingUnit
{
    public class CentralProcessingUnitCreateFormViewModel : ProductCreateFormViewModel
    {
        [Display(Name="Cores")]
        [Range(1, 100, ErrorMessage = "Number of cores must be at least 1.")]
        public int NumberOfCores { get; set; }

        [Display(Name = "Threads")]
        [Range(1, 100, ErrorMessage = "Number of threads must be at least 1.")]
        public int NumberOfThreads { get; set; }

        [Required]
        [Display(Name="Clock speed")]
        public string ClockSpeed { get; set; }

        [Required]
        [Display(Name="TDP")]
        public string TDP { get; set; }

        [Required]
        [Display(Name="Socket")]
        public string Socket { get; set; }

        [Required]
        [Display(Name="Architecture")]
        public string Architecture { get; set; }

        [Required]
        [Display(Name="Manufacturing process")]
        public string ManufacturingProcess { get; set; }
    }
}
