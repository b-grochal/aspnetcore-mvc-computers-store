using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputersStore.Services.Extensions
{
    public static class ProductsExtension
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> source, string sortOrder)
        {
            switch(sortOrder)
            {
                case "Price ASC":
                    return source.OrderBy(p => p.Price);
                case "Price DSC":
                    return source.OrderByDescending(p => p.Price);
                default:
                    return source.OrderBy(p => p.ProductId);
            }
        }
    }
}
