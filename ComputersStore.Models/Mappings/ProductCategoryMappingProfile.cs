using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.ProductCategory.Base;

namespace ComputersStore.Models.Mappings
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
