using AutoMapper;
using ComputersStore.Core.Data;
using ComputersStore.Models.Converters;
using ComputersStore.Models.ViewModels;
using ComputersStore.Models.ViewModels.Basic;
using Microsoft.AspNetCore.Http;
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
            CreateMap<IFormFile, byte[]>().ConvertUsing<ImageFileConverter>();

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

            CreateMap<NewProductViewModel, CentralProcessingUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<NewProductViewModel, GraphicsProcessingUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<NewProductViewModel, HardDiskDrive>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<NewProductViewModel, Motherboard>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<NewProductViewModel, PowerSupplyUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<NewProductViewModel, RandomAccessMemory>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<NewProductViewModel, SolidStateDrive>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));

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
