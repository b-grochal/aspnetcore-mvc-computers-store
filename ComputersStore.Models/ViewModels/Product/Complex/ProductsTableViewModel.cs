using ComputersStore.Models.SearchParams.Product;
using ComputersStore.Models.ViewModels.Other;
using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Complex
{
    public class ProductsTableViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public ProductsTableSearchParams ProductsTableSearchCriteria { get; set; }
    }
}
