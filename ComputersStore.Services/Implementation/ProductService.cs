using ComputersStore.Core.Data;
using ComputersStore.Data;
using ComputersStore.Services.Extensions;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputersStore.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ProductService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void AddProduct(Product product)
        {
            applicationDbContext.Products.Add(product);
            applicationDbContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            applicationDbContext.Products.Remove(product);
            applicationDbContext.SaveChanges();
        }

        public Product GetProduct(int productId)
        {
            return applicationDbContext.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public IEnumerable<Product> GetProductsCollection()
        {
            return applicationDbContext.Products.ToList();
        }

        public IEnumerable<Product> GetProductsCollection(ProductCategory productCategory, string sortOrder, int pageNumber, int pageSize)
        {
            return applicationDbContext.Products
                .Where(p => p.ProductCategory == productCategory)
                .Sort(sortOrder)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public void UpdateProduct(Product product)
        {
            applicationDbContext.Products.Update(product);
            applicationDbContext.SaveChanges();
        }
    }
}
