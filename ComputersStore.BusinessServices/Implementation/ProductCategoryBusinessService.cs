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
        private readonly IProductCategoryService productCategoryService;
        private readonly IMapper mapper;

        public ProductCategoryBusinessService(IProductCategoryService productCategoryService, IMapper mapper)
        {
            this.productCategoryService = productCategoryService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductCategoryViewModel>> GetProductsCategoriesCollection()
        {
            var productsCategories = await productCategoryService.GetProductCategoriesCollection();
            var result = mapper.Map<IEnumerable<ProductCategoryViewModel>>(productsCategories);
            return result;
        }
    }
}
