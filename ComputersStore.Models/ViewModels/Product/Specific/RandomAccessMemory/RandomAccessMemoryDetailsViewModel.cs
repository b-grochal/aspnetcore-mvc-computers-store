using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific
{
    public class RandomAccessMemoryDetailsViewModel : ProductDetailsViewModel
    {
        [Display(Name="Size")]
        public string Size { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Speed")]
        public string Speed { get; set; }

        [Display(Name = "CAS Latency (CL)")]
        public string CasLatency { get; set; }
    }
}
