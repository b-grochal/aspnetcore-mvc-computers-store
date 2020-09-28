using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Data.Entities
{
    public class RandomAccessMemory : Product
    {
        public string Size { get; set; }
        public string Type { get; set; }
        public string Speed { get; set; }
        public string CasLatency { get; set; }
    }
}
