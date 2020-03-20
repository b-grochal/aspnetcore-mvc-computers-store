using AutoMapper;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.Mappings
{
    public class ProductsMappingProfile : Profile
    {
        public ProductsMappingProfile()
        {
            //CreateMap<ProductViewModel, Product>();
            //CreateMap<Product, ProductViewModel>();
            CreateMap<CentralProcessingUnit, ProductViewModel>();
        }
    }
}
