﻿using AutoMapper;
using ComputersStore.Core.Data;
using ComputersStore.Models.Converters;
using ComputersStore.Models.Resolvers;
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
                .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<GraphicsProcessingUnit, ProductViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<CentralProcessingUnit, ProductViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<GraphicsProcessingUnit, ProductViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<HardDiskDrive, ProductViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<Motherboard, ProductViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<PowerSupplyUnit, ProductViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<RandomAccessMemory, ProductViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<SolidStateDrive, ProductViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));

            CreateMap<CentralProcessingUnit, ProductDetailsViewModel>()
                .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<GraphicsProcessingUnit, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<CentralProcessingUnit, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<GraphicsProcessingUnit, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<HardDiskDrive, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<Motherboard, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<PowerSupplyUnit, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<RandomAccessMemory, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<SolidStateDrive, ProductDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));

            CreateMap<ProductCreateFormViewModel, CentralProcessingUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<ProductCreateFormViewModel, GraphicsProcessingUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<ProductCreateFormViewModel, HardDiskDrive>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<ProductCreateFormViewModel, Motherboard>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<ProductCreateFormViewModel, PowerSupplyUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<ProductCreateFormViewModel, RandomAccessMemory>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<ProductCreateFormViewModel, SolidStateDrive>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));

            CreateMap<ProductEditFormViewModel, CentralProcessingUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom<ProductUpdatedImageResolver>());
            CreateMap<ProductEditFormViewModel, GraphicsProcessingUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom<ProductUpdatedImageResolver>());
            CreateMap<ProductEditFormViewModel, HardDiskDrive>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom<ProductUpdatedImageResolver>());
            CreateMap<ProductEditFormViewModel, Motherboard>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom<ProductUpdatedImageResolver>());
            CreateMap<ProductEditFormViewModel, PowerSupplyUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom<ProductUpdatedImageResolver>());
            CreateMap<ProductEditFormViewModel, RandomAccessMemory>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom<ProductUpdatedImageResolver>());
            CreateMap<ProductEditFormViewModel, SolidStateDrive>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom<ProductUpdatedImageResolver>());

            CreateMap<CentralProcessingUnit, ProductEditFormViewModel>();
            CreateMap<GraphicsProcessingUnit, ProductEditFormViewModel>();
            CreateMap<CentralProcessingUnit, ProductEditFormViewModel>();
            CreateMap<GraphicsProcessingUnit, ProductEditFormViewModel>();
            CreateMap<HardDiskDrive, ProductEditFormViewModel>();
            CreateMap<Motherboard, ProductEditFormViewModel>();
            CreateMap<PowerSupplyUnit, ProductEditFormViewModel>();
            CreateMap<RandomAccessMemory, ProductEditFormViewModel>();
            CreateMap<SolidStateDrive, ProductEditFormViewModel>();
        }
    }
}
