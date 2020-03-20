using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.Specific;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Complex
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PaginationViewModel PaginationInfo { get; set; }
        public ProductCategory CurrentProductCategory { get; set; }
    }
}
