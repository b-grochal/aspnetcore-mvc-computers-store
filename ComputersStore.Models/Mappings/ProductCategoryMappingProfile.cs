using AutoMapper;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Text;

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
