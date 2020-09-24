using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public string SortOrder { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
