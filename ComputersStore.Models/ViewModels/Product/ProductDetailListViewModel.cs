using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product
{
    public class ProductDetailListViewModel
    {
        public IEnumerable<ProductDetailsViewModel> Products { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public int ProductCategoryId { get; set; }
        public string SortOrder { get; set; }
    }
}
