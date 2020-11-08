﻿using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Data.Entities;
using ComputersStore.Data.Dictionaries;
using ComputersStore.Models.SearchParams.Product;
using ComputersStore.Models.ViewModels;
using ComputersStore.Models.ViewModels.Other;
using ComputersStore.Models.ViewModels.Product;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputersStore.Models.ViewModels.Product.Specific;
using ComputersStore.Models.ViewModels.Product.Specific.CentralProcessingUnit;
using ComputersStore.Models.ViewModels.Product.Specific.GraphicsProcessingUnit;
using ComputersStore.Models.ViewModels.Product.Specific.HardDiskDrive;
using ComputersStore.Models.ViewModels.Product.Specific.Motherboard;
using ComputersStore.Models.ViewModels.Product.Specific.PowerSupplyUnit;
using ComputersStore.Models.ViewModels.Product.Specific.RandomAccessMemory;
using ComputersStore.Models.ViewModels.Product.Specific.SolidStateDrive;
using ComputersStore.Models.ViewModels.Product.Complex;
using ComputersStore.Models.ViewModels.Product.Base;

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

        public async Task CreateProduct(ProductCreateFormViewModel newProductViewModel)
        {
            var product = MapNewProductViewModelToSpecificProduct(newProductViewModel);
            await productService.CreateProduct(product); 
        }

        public async Task DeleteProduct(int productId)
        {
            await productService.DeleteProduct(productId);
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsCollection(int productCategroryId, string sortOrder, int pageNumber, int pageSize)
        {
            var products = await productService.GetProductsCollection(productCategroryId, sortOrder, pageNumber, pageSize);
            var result = mapper.Map<IEnumerable<ProductViewModel>>(products);
            return result;
        }

        public int GetProductsCollectionCount(int productCategoryId)
        {
            return productService.GetProductsCollectionCount(productCategoryId);
        }

        public async Task<ProductDetailsViewModel> GetProductDetails(int productId)
        {
            var product = await productService.GetProduct(productId);
            var result = MapProductToSpecificDetailsViewModel(product);
            return result;
        }

        public async Task<ProductEditFormViewModel> GetProductForUpdate(int productId)
        {
            var product = await productService.GetProduct(productId);
            var result = MapProductToSpceificEditFormViewModel(product);
            return result;
        }

        public async Task UpdateProduct(ProductEditFormViewModel updatedProduct)
        {
            var product = MapProductEditFormViewModelToConcreteProduct(updatedProduct);
            await productService.UpdateProduct(product);
        }

        public async Task<IEnumerable<ProductViewModel>> GetRecommendedProductsCollection(int numberOfProducts)
        {
            var recommendedProducts = await productService.GetRecommendedProductsCollection(numberOfProducts);
            var result = mapper.Map<IEnumerable<ProductViewModel>>(recommendedProducts);
            return result;
        }

        public async Task<ProductViewModel> GetProduct(int productId)
        {
            var product = await productService.GetProduct(productId);
            var result = mapper.Map<ProductViewModel>(product);
            return result;
        }

        public async Task<SearchedProductsListViewModel> GetSearchedProductsCollection(string searchString)
        {
            var searchedProducts = await productService.GetSearchedProductsCollection(searchString);
            var result = new SearchedProductsListViewModel
            {
                Products = mapper.Map<IEnumerable<ProductViewModel>>(searchedProducts),
                SearchString = searchString
            };
            return result;
        }

        public async Task<ProductsTableViewModel> GetProductsCollectionForTable(int? productCategoryId, string productName, bool? isRecommended, int pageNumber, int pageSize)
        {
            var products = await productService.GetProductsCollection(productCategoryId, productName, isRecommended);
            var mappedProducts = mapper.Map<IEnumerable<ProductViewModel>>(products.Skip((pageNumber - 1) * pageSize).Take(pageSize));
            return new ProductsTableViewModel
            {
                Products = mappedProducts,
                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = pageSize,
                    TotalItems = products.Count()
                },
                ProductsTableSearchCriteria = new ProductsTableSearchParams
                {
                    ProductCategoryId = productCategoryId,
                    ProductName = productName,
                    IsRecommended = isRecommended
                }

            };
        }

        public ProductCreateFormViewModel PrepareNewEmptyProduct(int productCategoryId)
        {
            return productCategoryId switch
            {
                ProductCategoryDictionary.CPU => new CentralProcessingUnitCreateFormViewModel { ProductCategoryId = productCategoryId },
                ProductCategoryDictionary.GPU => new GraphicsProcessingUnitCreateFormViewModel { ProductCategoryId = productCategoryId },
                ProductCategoryDictionary.HDD => new HardDiskDriveCreateFormViewModel { ProductCategoryId = productCategoryId },
                ProductCategoryDictionary.Motherboard => new MotherboardCreateFormViewModel { ProductCategoryId = productCategoryId },
                ProductCategoryDictionary.PSU => new PowerSupplyUnitCreateFormViewModel { ProductCategoryId = productCategoryId },
                ProductCategoryDictionary.RAM => new RandomAccessMemoryCreateFormViewModel { ProductCategoryId = productCategoryId },
                ProductCategoryDictionary.SSD => new SolidStateDriveCreateFormViewModel { ProductCategoryId = productCategoryId },
                _ => null,
            };
        }

        private Product MapNewProductViewModelToSpecificProduct(ProductCreateFormViewModel newProduct)
        {
            return newProduct.ProductCategoryId switch
            {
                ProductCategoryDictionary.CPU => mapper.Map<CentralProcessingUnit>(newProduct),
                ProductCategoryDictionary.GPU => mapper.Map<GraphicsProcessingUnit>(newProduct),
                ProductCategoryDictionary.HDD => mapper.Map<HardDiskDrive>(newProduct),
                ProductCategoryDictionary.Motherboard => mapper.Map<Motherboard>(newProduct),
                ProductCategoryDictionary.PSU => mapper.Map<PowerSupplyUnit>(newProduct),
                ProductCategoryDictionary.RAM => mapper.Map<RandomAccessMemory>(newProduct),
                ProductCategoryDictionary.SSD => mapper.Map<SolidStateDrive>(newProduct),
                _ => null,
            };
        }

        private ProductDetailsViewModel MapProductToSpecificDetailsViewModel(Product product)
        {
            return product.ProductCategoryId switch
            {
                ProductCategoryDictionary.CPU => mapper.Map<CentralProcessingUnitDetailsViewModel>(product),
                ProductCategoryDictionary.GPU => mapper.Map<GraphicsProcessingUnitDetailsViewModel>(product),
                ProductCategoryDictionary.HDD => mapper.Map<HardDiskDriveDetailsViewModel>(product),
                ProductCategoryDictionary.Motherboard => mapper.Map<MotherboardDetailsViewModel>(product),
                ProductCategoryDictionary.PSU => mapper.Map<PowerSupplyUnitDetailsViewModel>(product),
                ProductCategoryDictionary.RAM => mapper.Map<RandomAccessMemoryDetailsViewModel>(product),
                ProductCategoryDictionary.SSD => mapper.Map<SolidStateDriveDetailsViewModel>(product),
                _ => null,
            };
        }

        private ProductEditFormViewModel MapProductToSpceificEditFormViewModel(Product product)
        {
            return product.ProductCategoryId switch
            {
                ProductCategoryDictionary.CPU => mapper.Map<CentralProcessingUnitEditFormViewModel>(product),
                ProductCategoryDictionary.GPU => mapper.Map<GraphicsProcessingUnitEditFormViewModel>(product),
                ProductCategoryDictionary.HDD => mapper.Map<HardDiskDriveEditFormViewModel>(product),
                ProductCategoryDictionary.Motherboard => mapper.Map<MotherboardEditFormViewModel>(product),
                ProductCategoryDictionary.PSU => mapper.Map<PowerSupplyUnitEditFormViewModel>(product),
                ProductCategoryDictionary.RAM => mapper.Map<RandomAccessMemoryEditFormViewModel>(product),
                ProductCategoryDictionary.SSD => mapper.Map<SolidStateDriveEditFormViewModel>(product),
                _ => null,
            };
        }

        private Product MapProductEditFormViewModelToConcreteProduct(ProductEditFormViewModel productDetailsViewModel)
        {
            return productDetailsViewModel.ProductCategoryId switch
            {
                ProductCategoryDictionary.CPU => mapper.Map<CentralProcessingUnit>(productDetailsViewModel),
                ProductCategoryDictionary.GPU => mapper.Map<GraphicsProcessingUnit>(productDetailsViewModel),
                ProductCategoryDictionary.HDD => mapper.Map<HardDiskDrive>(productDetailsViewModel),
                ProductCategoryDictionary.Motherboard => mapper.Map<Motherboard>(productDetailsViewModel),
                ProductCategoryDictionary.PSU => mapper.Map<PowerSupplyUnit>(productDetailsViewModel),
                ProductCategoryDictionary.RAM => mapper.Map<RandomAccessMemory>(productDetailsViewModel),
                ProductCategoryDictionary.SSD => mapper.Map<SolidStateDrive>(productDetailsViewModel),
                _ => null,
            };
        }
    }
}
