using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsCollection();
        IEnumerable<Product> GetProductsCollection(int productCategoryId, string sortOrder, int pageNumber, int pageSize);
        Product GetProduct(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        int GetProductsCollectionCount(int productCategoryId);
        IEnumerable<Product> GetRecommendedProductsCollection(int numberOfProducts);
    }
}
