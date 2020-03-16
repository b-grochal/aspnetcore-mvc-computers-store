using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Core.Data
{
    public class GraphicsProcessingUnit : Product
    {
        public string MemorySize { get; set; }
        public string MemoryType { get; set; }
        public string MemorySpeed { get; set; }
        public string MemoryBus { get; set; }
        public string Interface { get; set; }
    }
}
