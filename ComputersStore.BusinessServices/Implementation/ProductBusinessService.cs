﻿using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels;
using ComputersStore.Models.ViewModels.Basic;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.BusinessServices.Implementation
{
    public class ProductBusinessService : IProductBusinessService
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public ProductBusinessService(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public void AddProduct(NewProductViewModel newProductViewModel)
        {
            var product = MapNewProductViewModelToConcreteProduct(newProductViewModel);
            productService.AddProduct(product); 
        }

        public void DeleteProduct(ProductViewModel productViewModel)
        {
            var product = MapProductViewModelToConcreteProduct(productViewModel);
            productService.DeleteProduct(product);
        }

        public ProductDetailsViewModel GetProduct(int productId)
        {
            var product = productService.GetProduct(productId);
            var result = mapper.Map<ProductDetailsViewModel>(product);
            return result;
        }

        public IEnumerable<ProductViewModel> GetProductsCollection()
        {
            var products = productService.GetProductsCollection();
            var result = mapper.Map<IEnumerable<ProductViewModel>>(products);
            return result;
        }

        public IEnumerable<ProductViewModel> GetProductsCollection(ProductCategory productCategory, string sortOrder, int pageNumber, int pageSize)
        {

            var products = productService.GetProductsCollection(productCategory, sortOrder, pageNumber, pageSize);
            var result = mapper.Map<IEnumerable<ProductViewModel>>(products);
            return result;
        }

        public void UpdateProduct(ProductDetailsViewModel productDetailsViewModel)
        {
            var product = MapProductDetailsViewModelToConcreteProduct(productDetailsViewModel);
            productService.UpdateProduct(product);
        }

        private Product MapNewProductViewModelToConcreteProduct(NewProductViewModel newProduct)
        {
            Product result = null;
            switch(newProduct.ProductCategory)
            {
                case ProductCategory.CPU:
                    result = mapper.Map<CentralProcessingUnit>(newProduct);
                    break;
                case ProductCategory.GPU:
                    result = mapper.Map<GraphicsProcessingUnit>(newProduct);
                    break;
                case ProductCategory.HDD:
                    result = mapper.Map<HardDiskDrive>(newProduct);
                    break;
                case ProductCategory.Motherboard:
                    result = mapper.Map<Motherboard>(newProduct);
                    break;
                case ProductCategory.PSU:
                    result = mapper.Map<PowerSupplyUnit>(newProduct);
                    break;
                case ProductCategory.RAM:
                    result = mapper.Map<RandomAccessMemory>(newProduct);
                    break;
                case ProductCategory.SSD:
                    result = mapper.Map<SolidStateDrive>(newProduct);
                    break;
            }
            return result;
        }

        private Product MapProductViewModelToConcreteProduct(ProductViewModel productViewModel)
        {
            Product result = null;
            switch (productViewModel.ProductCategory)
            {
                case ProductCategory.CPU:
                    result = mapper.Map<CentralProcessingUnit>(productViewModel);
                    break;
                case ProductCategory.GPU:
                    result = mapper.Map<GraphicsProcessingUnit>(productViewModel);
                    break;
                case ProductCategory.HDD:
                    result = mapper.Map<HardDiskDrive>(productViewModel);
                    break;
                case ProductCategory.Motherboard:
                    result = mapper.Map<Motherboard>(productViewModel);
                    break;
                case ProductCategory.PSU:
                    result = mapper.Map<PowerSupplyUnit>(productViewModel);
                    break;
                case ProductCategory.RAM:
                    result = mapper.Map<RandomAccessMemory>(productViewModel);
                    break;
                case ProductCategory.SSD:
                    result = mapper.Map<SolidStateDrive>(productViewModel);
                    break;
            }
            return result;
        }

        private Product MapProductDetailsViewModelToConcreteProduct(ProductDetailsViewModel productDetailsViewModel)
        {
            Product result = null;
            switch (productDetailsViewModel.ProductCategory)
            {
                case ProductCategory.CPU:
                    result = mapper.Map<CentralProcessingUnit>(productDetailsViewModel);
                    break;
                case ProductCategory.GPU:
                    result = mapper.Map<GraphicsProcessingUnit>(productDetailsViewModel);
                    break;
                case ProductCategory.HDD:
                    result = mapper.Map<HardDiskDrive>(productDetailsViewModel);
                    break;
                case ProductCategory.Motherboard:
                    result = mapper.Map<Motherboard>(productDetailsViewModel);
                    break;
                case ProductCategory.PSU:
                    result = mapper.Map<PowerSupplyUnit>(productDetailsViewModel);
                    break;
                case ProductCategory.RAM:
                    result = mapper.Map<RandomAccessMemory>(productDetailsViewModel);
                    break;
                case ProductCategory.SSD:
                    result = mapper.Map<SolidStateDrive>(productDetailsViewModel);
                    break;
            }
            return result;
        }
    }
}