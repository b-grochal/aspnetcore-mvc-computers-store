using ComputersStore.Models.ViewModels.PaymentType;
using ComputersStore.Models.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IProductCategoryBusinessService
    {
        Task<IEnumerable<ProductCategoryViewModel>> GetProductsCategoriesCollection();
    }
}
