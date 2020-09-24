using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputersStore.Data.Entities 
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
