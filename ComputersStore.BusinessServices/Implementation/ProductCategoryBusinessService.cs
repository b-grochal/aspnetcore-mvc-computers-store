using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.ProductCategory.Base;
using ComputersStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class ProductCategoryBusinessService : IProductCategoryBusinessService
    {
        #region Fields

        private readonly IProductCategoryService productCategoryService;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        public ProductCategoryBusinessService(IProductCategoryService productCategoryService, IMapper mapper)
        {
            this.productCategoryService = productCategoryService;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Public methods

        public async Task<IEnumerable<ProductCategoryViewModel>> GetProductsCategoriesCollection()
        {
            var productsCategories = await productCategoryService.GetProductCategoriesCollection();
            var result = mapper.Map<IEnumerable<ProductCategoryViewModel>>(productsCategories);
            return result;
        }

        #endregion Public methods
    }
}
