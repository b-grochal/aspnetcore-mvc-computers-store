using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Data.Entities
{
    public class HardDiskDrive : Product
    {
        public string Capacity { get; set; }
        public string RotationSpeed { get; set; }
        public string CacheSize { get; set; }
        public string Interface { get; set; }
    }
}
