using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product
{
    public class SearchedProductsListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public string SearchString { get; set; }
    }
}
