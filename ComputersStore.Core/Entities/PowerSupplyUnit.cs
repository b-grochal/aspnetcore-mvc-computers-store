using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Data.Entities
{
    public class PowerSupplyUnit : Product
    {
        public string Size { get; set; }
        public string Wattage { get; set; }
    }
}
