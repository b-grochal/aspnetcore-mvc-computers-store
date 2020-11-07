using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Complex
{
    public class SearchedProductsListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public string SearchString { get; set; }
    }
}
