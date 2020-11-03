using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specific
{
    public class SolidStateDriveDetailsViewModel : ProductDetailsViewModel
    {
        public string Capacity { get; set; }
        public string Interface { get; set; }
    }
}
