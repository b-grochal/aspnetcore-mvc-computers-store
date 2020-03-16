using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Core.Data
{
    public class Motherboard : Product
    {
        public string FormFactor { get; set; }
        public string CpuSocket { get; set; }
        public string Chipset { get; set; }
        public string MemoryType { get; set; }
        public string MemoryChannel { get; set; }
        public string SataSupport { get; set; }
    }
}
