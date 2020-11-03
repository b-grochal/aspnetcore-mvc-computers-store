﻿using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.Converters;
using ComputersStore.Models.Resolvers;
using ComputersStore.Models.ViewModels;
using ComputersStore.Models.ViewModels.Product;
using ComputersStore.Models.ViewModels.Product.Specific;
using ComputersStore.Models.ViewModels.Product.Specific.CentralProcessingUnit;
using ComputersStore.Models.ViewModels.Product.Specific.GraphicsProcessingUnit;
using ComputersStore.Models.ViewModels.Product.Specific.HardDiskDrive;
using ComputersStore.Models.ViewModels.Product.Specific.Motherboard;
using ComputersStore.Models.ViewModels.Product.Specific.PowerSupplyUnit;
using ComputersStore.Models.ViewModels.Product.Specific.RandomAccessMemory;
using ComputersStore.Models.ViewModels.Product.Specific.SolidStateDrive;
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

            CreateMap<CentralProcessingUnit, CentralProcessingUnitDetailsViewModel>()
                .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<GraphicsProcessingUnit, GraphicsProcessingUnitDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<HardDiskDrive, HardDiskDriveDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<Motherboard, MotherboardDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<PowerSupplyUnit, PowerSupplyUnitDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<RandomAccessMemory, RandomAccessMemoryDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
            CreateMap<SolidStateDrive, SolidStateDriveDetailsViewModel>()
                 .ForMember(dest => dest.ImageDataUrl, opt => opt.MapFrom(src => src.Image))
                 .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));

            CreateMap<CentralProcessingUnitCreateFormViewModel, CentralProcessingUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<GraphicsProcessingUnitCreateFormViewModel, GraphicsProcessingUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<HardDiskDriveCreateFormViewModel, HardDiskDrive>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<MotherboardCreateFormViewModel, Motherboard>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<PowerSupplyUnitCreateFormViewModel, PowerSupplyUnit>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<RandomAccessMemoryCreateFormViewModel, RandomAccessMemory>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageFile));
            CreateMap<SolidStateDriveCreateFormViewModel, SolidStateDrive>()
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
