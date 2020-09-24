using ComputersStore.Models.SearchCriteria.Products;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product
{
    public class ProductsTableViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public ProductsTableSearchCriteria ProductsTableSearchCriteria { get; set; }
    }
}
