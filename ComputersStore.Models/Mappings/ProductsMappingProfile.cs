using AutoMapper;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels;
using ComputersStore.Models.ViewModels.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.Mappings
{
    public class ProductsMappingProfile : Profile
    {
        public ProductsMappingProfile()
        {
            CreateMap<CentralProcessingUnit, ProductViewModel>();
            CreateMap<CentralProcessingUnit, ProductDetailsViewModel>();
            CreateMap<GraphicsProcessingUnit, ProductDetailsViewModel>();
            CreateMap<HardDiskDrive, ProductDetailsViewModel>();
            CreateMap<Motherboard, ProductDetailsViewModel>();
            CreateMap<PowerSupplyUnit, ProductDetailsViewModel>();
            CreateMap<RandomAccessMemory, ProductDetailsViewModel>();
            CreateMap<SolidStateDrive, ProductDetailsViewModel>();
            CreateMap<NewProductViewModel, CentralProcessingUnit>();
            CreateMap<NewProductViewModel, GraphicsProcessingUnit>();
            CreateMap<NewProductViewModel, HardDiskDrive>();
            CreateMap<NewProductViewModel, Motherboard>();
            CreateMap<NewProductViewModel, PowerSupplyUnit>();
            CreateMap<NewProductViewModel, RandomAccessMemory>();
            CreateMap<NewProductViewModel, SolidStateDrive>();
        }
    }
}
