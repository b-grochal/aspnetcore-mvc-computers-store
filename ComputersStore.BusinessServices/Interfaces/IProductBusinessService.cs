using ComputersStore.Models.ViewModels.Product.Base;
using ComputersStore.Models.ViewModels.Product.Complex;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IProductBusinessService
    {
        Task<ProductsCollectionViewModel> GetProductsCollection(int productCategroryId, string sortOrder, int pageNumber, int pageSize);
        Task<ProductDetailsViewModel> GetProductDetails(int productId);
        Task<ProductEditFormViewModel> GetProductEditData(int productId);
        Task CreateProduct(ProductCreateFormViewModel product);
        Task UpdateProduct(ProductEditFormViewModel product);
        Task DeleteProduct(int productId);
        ProductCreateFormViewModel PrepareNewEmptyProduct(int productCategoryId);
        Task<IEnumerable<ProductViewModel>> GetRecommendedProductsCollection(int numberOfProducts);
        Task<ProductViewModel> GetProduct(int productId);
        Task<ProductsSearchedCollectionViewModel> GetProductsSearchedCollection(string searchString);
        Task<ProductsFilteredCollectionViewModel> GetProductsFilteredCollection(int? productCategoryId, string productName, bool? isRecommended, int pageNumber, int pageSize);
    }
}
