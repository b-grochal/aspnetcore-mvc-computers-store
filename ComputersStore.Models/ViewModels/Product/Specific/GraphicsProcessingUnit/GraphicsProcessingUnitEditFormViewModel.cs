using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.GraphicsProcessingUnit
{
    public class GraphicsProcessingUnitEditFormViewModel : ProductEditFormViewModel
    {
        public string MemorySize { get; set; }
        public string MemoryType { get; set; }
        public string MemorySpeed { get; set; }
        public string MemoryBus { get; set; }
        public string Interface { get; set; }
    }
}
