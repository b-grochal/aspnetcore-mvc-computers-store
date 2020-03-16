using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Core.Data
{
    public abstract class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
