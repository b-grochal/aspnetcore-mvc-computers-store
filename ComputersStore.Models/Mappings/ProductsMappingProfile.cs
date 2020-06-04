using AutoMapper;
using ComputersStore.Core.Data;
using ComputersStore.Models.Converters;
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
            CreateMap<byte[], string>().ConvertUsing<ImageByteArrayConverter>();

            CreateMap<CentralProcessingUnit, ProductViewModel>()
                .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image));
            CreateMap<GraphicsProcessingUnit, ProductViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image));
            CreateMap<CentralProcessingUnit, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image));
            CreateMap<GraphicsProcessingUnit, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image));
            CreateMap<HardDiskDrive, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image));
            CreateMap<Motherboard, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image));
            CreateMap<PowerSupplyUnit, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image));
            CreateMap<RandomAccessMemory, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image));
            CreateMap<SolidStateDrive, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image));

            CreateMap<NewProductViewModel, CentralProcessingUnit>();
            CreateMap<NewProductViewModel, GraphicsProcessingUnit>();
            CreateMap<NewProductViewModel, HardDiskDrive>();
            CreateMap<NewProductViewModel, Motherboard>();
            CreateMap<NewProductViewModel, PowerSupplyUnit>();
            CreateMap<NewProductViewModel, RandomAccessMemory>();
            CreateMap<NewProductViewModel, SolidStateDrive>();
            CreateMap<ProductDetailsViewModel, CentralProcessingUnit>();
            CreateMap<ProductDetailsViewModel, GraphicsProcessingUnit>();
            CreateMap<ProductDetailsViewModel, HardDiskDrive>();
            CreateMap<ProductDetailsViewModel, Motherboard>();
            CreateMap<ProductDetailsViewModel, PowerSupplyUnit>();
            CreateMap<ProductDetailsViewModel, RandomAccessMemory>();
            CreateMap<ProductDetailsViewModel, SolidStateDrive>();

        }
    }
}
