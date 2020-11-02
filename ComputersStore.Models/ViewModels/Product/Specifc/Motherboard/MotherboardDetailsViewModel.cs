using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specifc
{
    public class MotherboardDetailsViewModel : ProductDetailsViewModel
    {
        public string FormFactor { get; set; }
        public string CpuSocket { get; set; }
        public string Chipset { get; set; }
        public string MemoryType { get; set; }
        public string MemoryChannel { get; set; }
        public string SataSupport { get; set; }
    }
}
