using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels;
using ComputersStore.Models.ViewModels.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IProductBusinessService
    {
        IEnumerable<ProductViewModel> GetProductsCollection();
        IEnumerable<ProductDetailsViewModel> GetProductsDetailCollection(ProductCategory productCategrory, string sortOrder, int pageNumber, int pageSize);
        ProductDetailsViewModel GetProductDetails(int productId);
        ProductEditFormViewModel GetProductEditFormData(int productId);
        void AddProduct(ProductCreateFormViewModel product);
        void UpdateProduct(ProductEditFormViewModel product);
        void DeleteProduct(ProductViewModel product);
        int GetProductsCollectionCount(ProductCategory productCategory);
    }
}
