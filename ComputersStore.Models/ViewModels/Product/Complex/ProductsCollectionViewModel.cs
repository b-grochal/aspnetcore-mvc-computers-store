﻿using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.Other;
using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Complex
{
    public class ProductsCollectionViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public string SortOrder { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
