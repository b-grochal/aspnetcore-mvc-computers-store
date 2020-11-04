using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific.SolidStateDrive
{
    public class SolidStateDriveEditFormViewModel : ProductEditFormViewModel
    {
        public string Capacity { get; set; }
        public string Interface { get; set; }
    }
}
