using ComputersStore.Data.Entities;
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
        #region Fields

        private readonly ApplicationDbContext applicationDbContext;

        #endregion Fields

        #region Constructors

        public ProductService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        #endregion Constructors

        #region Public methods

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

        public async Task<int> GetProductsCollectionCount(int productCategoryId)
        {
            return await applicationDbContext.Products
                .Where(p => p.ProductCategoryId == productCategoryId)
                .CountAsync();
        }

        public async Task<int> GetProductsCollectionCount(int? productCategoryId, string productName, bool? isRecommended)
        {
            return await applicationDbContext.Products
                .Where(p => productCategoryId == null || p.ProductCategoryId == productCategoryId)
                .Where(p => productName == null || p.Name.Contains(productName))
                .Where(p => isRecommended == null || p.IsRecommended == isRecommended)
                .CountAsync();
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
            var recommendedProducts = await applicationDbContext.Products
                .Where(x => x.IsRecommended == true)
                .ToListAsync();

            return recommendedProducts
                .Randomize()
                .Take(numberOfProducts);
        }

        public async Task UpdateProduct(Product product)
        {
            applicationDbContext.Products.Update(product);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsCollection(IEnumerable<int> productsId)
        {
            return await applicationDbContext.Products.Where(p => productsId.Contains(p.ProductId)).ToListAsync(); 
        }

        public async Task<IEnumerable<Product>> GetProductsCollection(string searchString)
        {
            return await applicationDbContext.Products.Where(p => p.Name.ToLower().Contains(searchString.ToLower())).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsCollection(int? productCategoryId, string productName, bool? isRecommended, int pageNumber, int pageSize)
        {
            return await applicationDbContext.Products
                .Where(p => productCategoryId == null || p.ProductCategoryId == productCategoryId)
                .Where(p => productName == null || p.Name.Contains(productName))
                .Where(p => isRecommended == null || p.IsRecommended == isRecommended)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        #endregion Public methods
    }
}
