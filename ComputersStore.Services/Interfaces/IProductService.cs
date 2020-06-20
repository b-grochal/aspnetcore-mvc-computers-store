using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsCollection();
        IEnumerable<Product> GetProductsCollection(ProductCategory productCategory, string sortOrder, int pageNumber, int pageSize);
        Product GetProduct(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        int GetProductsCollectionCount(ProductCategory productCategory);
        IEnumerable<Product> GetRecommendedProductsCollection(int numberOfProducts);
    }
}
