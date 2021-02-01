using ComputersStore.Models.ViewModels.ProductCategory.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IProductCategoryBusinessService
    {
        Task<IEnumerable<ProductCategoryViewModel>> GetProductsCategoriesCollection();
    }
}
