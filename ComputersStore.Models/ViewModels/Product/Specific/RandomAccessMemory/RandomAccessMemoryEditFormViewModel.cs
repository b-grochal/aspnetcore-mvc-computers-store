using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.RandomAccessMemory
{
    public class RandomAccessMemoryEditFormViewModel : ProductEditFormViewModel
    {
        [Required]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Speed")]
        public string Speed { get; set; }

        [Required]
        [Display(Name = "CAS Latency (CL)")]
        public string CasLatency { get; set; }
    }
}
