using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.GraphicsProcessingUnit
{
    public class GraphicsProcessingUnitCreateFormViewModel : ProductCreateFormViewModel
    {
        [Required]
        [Display(Name = "Memory size")]
        public string MemorySize { get; set; }

        [Required]
        [Display(Name = "Memory type")]
        public string MemoryType { get; set; }

        [Required]
        [Display(Name = "Memory speed")]
        public string MemorySpeed { get; set; }

        [Required]
        [Display(Name = "Memory bus")]
        public string MemoryBus { get; set; }

        [Required]
        [Display(Name = "Interface")]
        public string Interface { get; set; }
    }
}
