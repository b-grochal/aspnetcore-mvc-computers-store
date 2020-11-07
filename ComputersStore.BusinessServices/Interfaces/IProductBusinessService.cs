using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels;
using ComputersStore.Models.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IProductBusinessService
    {
        Task<IEnumerable<ProductViewModel>> GetProductsCollection(int productCategroryId, string sortOrder, int pageNumber, int pageSize);
        Task<ProductDetailsViewModel> GetProductDetails(int productId);
        Task<ProductEditFormViewModel> GetProductForUpdate(int productId);
        Task CreateProduct(ProductCreateFormViewModel product);
        Task UpdateProduct(ProductEditFormViewModel product);
        Task DeleteProduct(int productId);
        ProductCreateFormViewModel PrepareNewEmptyProduct(int productCategoryId);
        int GetProductsCollectionCount(int productCategoryId);
        Task<IEnumerable<ProductViewModel>> GetRecommendedProductsCollection(int numberOfProducts);
        Task<ProductViewModel> GetProduct(int productId);
        Task<SearchedProductsListViewModel> GetSearchedProductsCollection(string searchString);
        Task<ProductsTableViewModel> GetProductsCollectionForTable(int? productCategoryId, string productName, bool? isRecommended, int pageNumber, int pageSize);
    }
}
