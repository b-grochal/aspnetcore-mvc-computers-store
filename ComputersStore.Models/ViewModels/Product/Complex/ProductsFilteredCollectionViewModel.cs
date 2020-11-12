using ComputersStore.Models.ViewModels.Other;
using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Complex
{
    public class ProductsFilteredCollectionViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public bool? IsRecommended { get; set; }
    }
}
