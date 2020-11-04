using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.HardDiskDrive
{
    public class HardDiskDriveEditFormViewModel : ProductEditFormViewModel
    {
        [Required]
        [Display(Name = "Capacity")]
        public string Capacity { get; set; }

        [Required]
        [Display(Name = "Rotation speed")]
        public string RotationSpeed { get; set; }

        [Required]
        [Display(Name = "Cache size")]
        public string CacheSize { get; set; }

        [Required]
        [Display(Name = "Interface")]
        public string Interface { get; set; }
    }
}
