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
        IEnumerable<ProductViewModel> GetProductsCollection(ProductCategory productCategrory, string sortOrder, int pageNumber, int pageSize);
        ProductDetailsViewModel GetProduct(int productId);
        void AddProduct(NewProductViewModel product);
        void UpdateProduct(ProductDetailsViewModel product);
        void DeleteProduct(ProductViewModel product);
        int GetProductsCollectionCount(ProductCategory productCategory);
    }
}
