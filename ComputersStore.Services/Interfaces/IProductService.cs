using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsCollectionById(IEnumerable<int> productsId);
        Task<IEnumerable<Product>> GetProductsCollection(int productCategoryId, string sortOrder, int pageNumber, int pageSize);
        Task<IEnumerable<Product>> GetProductsCollection(int? productCategoryId, string productName, bool? isRecommended);
        Task<Product> GetProduct(int productId);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
        int GetProductsCollectionCount(int productCategoryId);
        Task<IEnumerable<Product>> GetRecommendedProductsCollection(int numberOfProducts);
        Task<IEnumerable<Product>> GetSearchedProductsCollection(string searchString);
    }
}
