﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Specifc.SolidStateDrive
{
    public class SolidStateDriveCreateFormViewModel : ProductCreateFormViewModel
    {
        public string Capacity { get; set; }
        public string Interface { get; set; }
    }
}
