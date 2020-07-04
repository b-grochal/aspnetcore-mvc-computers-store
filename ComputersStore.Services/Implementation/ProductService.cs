using ComputersStore.Core.Data;
using ComputersStore.Data;
using ComputersStore.Database.DatabaseContext;
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

        public int GetProductsCollectionCount(int productCategoryId)
        {
            return applicationDbContext.Products
                .Where(p => p.ProductCategoryId == productCategoryId)
                .Count();
        }

        public IEnumerable<Product> GetProductsCollection(int productCategoryId, string sortOrder, int pageNumber, int pageSize)
        {
            return applicationDbContext.Products
                .Where(p => p.ProductCategoryId == productCategoryId)
                .Sort(sortOrder)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Product> GetRecommendedProductsCollection(int numberOfProducts)
        {
            return applicationDbContext.Products
                .Where(x => x.IsRecommended == true)
                .Take(numberOfProducts)
                .ToList();
        }

        public void UpdateProduct(Product product)
        {
            applicationDbContext.Products.Update(product);
            applicationDbContext.SaveChanges();
        }
    }
}
