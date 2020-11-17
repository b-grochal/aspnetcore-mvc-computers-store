using ComputersStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsCollection(IEnumerable<int> productsIds);
        Task<IEnumerable<Product>> GetProductsCollection(int productCategoryId, string sortOrder, int pageNumber, int pageSize);
        Task<IEnumerable<Product>> GetProductsCollection(int? productCategoryId, string productName, bool? isRecommended, int pageNumber, int pageSize);
        Task<IEnumerable<Product>> GetProductsCollection(string searchString);
        Task<Product> GetProduct(int productId);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
        Task<int> GetProductsCollectionCount(int productCategoryId);
        Task<int> GetProductsCollectionCount(int? productCategoryId, string productName, bool? isRecommended);
        Task<IEnumerable<Product>> GetRecommendedProductsCollection(int numberOfProducts);
    }
}
