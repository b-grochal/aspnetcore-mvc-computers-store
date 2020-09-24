using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.SearchCriteria.Products
{
    public class ProductsTableSearchCriteria
    {
        public int? ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public bool? IsRecommended { get; set; }
    }
}
