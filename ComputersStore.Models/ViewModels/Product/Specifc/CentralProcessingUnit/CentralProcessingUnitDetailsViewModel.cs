using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specifc
{
    public class CentralProcessingUnitDetailsViewModel : ProductDetailsViewModel
    {
        public int NumberOfCores { get; set; }
        public int NumberOfThreads { get; set; }
        public string ClockSpeed { get; set; }
        public string TDP { get; set; }
        public string Socket { get; set; }
        public string Architecture { get; set; }
        public string ManufacturingProcess { get; set; }
    }
}
