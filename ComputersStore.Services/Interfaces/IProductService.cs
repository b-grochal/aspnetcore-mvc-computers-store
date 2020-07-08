﻿using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsCollection();
        Task<IEnumerable<Product>> GetProductsCollection(int productCategoryId, string sortOrder, int pageNumber, int pageSize);
        Task<Product> GetProduct(int productId);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
        int GetProductsCollectionCount(int productCategoryId);
        Task<IEnumerable<Product>> GetRecommendedProductsCollection(int numberOfProducts);
    }
}
