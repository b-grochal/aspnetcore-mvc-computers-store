using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specifc
{
    public class RandomAccessMemoryDetailsViewModel : ProductDetailsViewModel
    {
        public string Size { get; set; }
        public string Type { get; set; }
        public string Speed { get; set; }
        public string CasLatency { get; set; }
    }
}
