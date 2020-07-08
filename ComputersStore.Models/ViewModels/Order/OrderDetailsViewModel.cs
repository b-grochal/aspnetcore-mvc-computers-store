﻿using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public ApplicationUserViewModel ApplicationUserViewModel {get; set;}
        public virtual IEnumerable<OrderItemViewModel> OrderItemsViewModel { get; set; }
    }
}