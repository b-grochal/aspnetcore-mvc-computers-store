using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels;
using ComputersStore.Models.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IProductBusinessService
    {
        IEnumerable<ProductViewModel> GetProductsCollection();
        IEnumerable<ProductDetailsViewModel> GetProductsDetailCollection(int productCategroryId, string sortOrder, int pageNumber, int pageSize);
        ProductDetailsViewModel GetProductDetails(int productId);
        ProductEditFormViewModel GetProductEditFormData(int productId);
        void AddProduct(ProductCreateFormViewModel product);
        void UpdateProduct(ProductEditFormViewModel product);
        void DeleteProduct(ProductViewModel product);
        int GetProductsCollectionCount(int productCategoryId);
        IEnumerable<ProductViewModel> GetRecommendedProductsCollection(int numberOfProducts);
    }
}
