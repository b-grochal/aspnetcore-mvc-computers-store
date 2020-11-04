using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.SolidStateDrive
{
    public class SolidStateDriveEditFormViewModel : ProductEditFormViewModel
    {
        [Required]
        [Display(Name = "Capacity")]
        public string Capacity { get; set; }

        [Required]
        [Display(Name = "Interface")]
        public string Interface { get; set; }
    }
}
