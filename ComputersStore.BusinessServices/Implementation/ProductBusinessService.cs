using AutoMapper;
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

        public void AddProduct(ProductCreateFormViewModel newProductViewModel)
        {
            var product = MapNewProductViewModelToConcreteProduct(newProductViewModel);
            productService.AddProduct(product); 
        }

        public void DeleteProduct(ProductViewModel productViewModel)
        {
            var product = MapProductViewModelToConcreteProduct(productViewModel);
            productService.DeleteProduct(product);
        }

        public IEnumerable<ProductViewModel> GetProductsCollection()
        {
            var products = productService.GetProductsCollection();
            var result = mapper.Map<IEnumerable<ProductViewModel>>(products);
            return result;
        }

        public int GetProductsCollectionCount(ProductCategory productCategory)
        {
            return productService.GetProductsCollectionCount(productCategory);
        }

        public IEnumerable<ProductDetailsViewModel> GetProductsDetailCollection(ProductCategory productCategrory, string sortOrder, int pageNumber, int pageSize)
        {
            var products = productService.GetProductsCollection(productCategrory, sortOrder, pageNumber, pageSize);
            var result = mapper.Map<IEnumerable<ProductDetailsViewModel>>(products);
            return result;
        }

        public ProductDetailsViewModel GetProductDetails(int productId)
        {
            var product = productService.GetProduct(productId);
            var result = mapper.Map<ProductDetailsViewModel>(product);
            return result;
        }

        public ProductEditFormViewModel GetProductEditFormData(int productId)
        {
            var product = productService.GetProduct(productId);
            var result = mapper.Map<ProductEditFormViewModel>(product);
            return result;
        }

        public void UpdateProduct(ProductEditFormViewModel updatedProduct)
        {
            var product = MapProductEditFormViewModelToConcreteProduct(updatedProduct);
            if(product.Image == null)
            {
                product.Image = GetProductImage(product.ProductId);
            }
            productService.UpdateProduct(product);
        }

        public IEnumerable<ProductViewModel> GetRecommendedProductsCollection(int numberOfProducts)
        {
            var recommendedProducts = productService.GetRecommendedProductsCollection(numberOfProducts);
            var result = mapper.Map<IEnumerable<ProductViewModel>>(recommendedProducts);
            return result;
        }

        private Product MapNewProductViewModelToConcreteProduct(ProductCreateFormViewModel newProduct)
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

        private Product MapProductEditFormViewModelToConcreteProduct(ProductEditFormViewModel productDetailsViewModel)
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

        private byte[] GetProductImage(int productId)
        {
            return productService.GetProduct(productId).Image;
        }
    }
}
