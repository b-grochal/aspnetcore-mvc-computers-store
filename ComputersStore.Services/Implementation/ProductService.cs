using ComputersStore.Core.Data;
using ComputersStore.Data;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Services.Extensions;
using ComputersStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ProductService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task CreateProduct(Product product)
        {
            await applicationDbContext.Products.AddAsync(product);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await applicationDbContext.Products.FindAsync(productId);
            applicationDbContext.Products.Remove(product);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await applicationDbContext.Products.FindAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetProductsCollection()
        {
            return await applicationDbContext.Products.ToListAsync();
        }

        public int GetProductsCollectionCount(int productCategoryId)
        {
            return applicationDbContext.Products
                .Where(p => p.ProductCategoryId == productCategoryId)
                .Count();
        }

        public async Task<IEnumerable<Product>> GetProductsCollection(int productCategoryId, string sortOrder, int pageNumber, int pageSize)
        {
            return await applicationDbContext.Products
                .Where(p => p.ProductCategoryId == productCategoryId)
                .Sort(sortOrder)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetRecommendedProductsCollection(int numberOfProducts)
        {
            return await applicationDbContext.Products
                .Where(x => x.IsRecommended == true)
                .Take(numberOfProducts)
                .ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            applicationDbContext.Products.Update(product);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsCollectionById(IEnumerable<int> productsId)
        {
            return await applicationDbContext.Products.Where(p => productsId.Contains(p.ProductId)).ToListAsync(); 
        }

        public async Task<IEnumerable<Product>> GetSearchedProductsCollection(string searchString)
        {
            return await applicationDbContext.Products.Where(p => p.Name.ToLower().Contains(searchString.ToLower())).ToListAsync();
        }
    }
}
