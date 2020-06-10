using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputersStore.Core.Data
{
    public enum ProductCategory
    {
        [Description("CPU")]
        CPU = 1,
        Motherboard,
        RAM,
        GPU,
        PSU,
        HDD,
        SSD
    }
}
