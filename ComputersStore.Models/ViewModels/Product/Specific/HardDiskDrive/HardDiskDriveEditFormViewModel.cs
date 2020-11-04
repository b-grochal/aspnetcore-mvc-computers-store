using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.HardDiskDrive
{
    public class HardDiskDriveEditFormViewModel : ProductEditFormViewModel
    {
        public string Capacity { get; set; }
        public string RotationSpeed { get; set; }
        public string CacheSize { get; set; }
        public string Interface { get; set; }
    }
}
