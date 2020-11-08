using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.SearchParams.Product
{
    public class ProductsTableSearchParams
    {
        public int? ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public bool? IsRecommended { get; set; }
    }
}
