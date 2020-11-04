using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific
{
    public class GraphicsProcessingUnitDetailsViewModel : ProductDetailsViewModel
    {
        [Display(Name="Memory size")]
        public string MemorySize { get; set; }

        [Display(Name = "Memory type")]
        public string MemoryType { get; set; }

        [Display(Name = "Memory speed")]
        public string MemorySpeed { get; set; }

        [Display(Name = "Memory bus")]
        public string MemoryBus { get; set; }

        [Display(Name = "Interface")]
        public string Interface { get; set; }
    }
}
