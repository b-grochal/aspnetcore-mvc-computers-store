using AutoMapper;
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
            if(product.Image == null)
            {
                product.Image = await GetProductImage(product.ProductId);
            }
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
            switch (productCategoryId)
            {
                case ProductCategoryDictionary.CPU:
                    return new CentralProcessingUnitCreateFormViewModel { ProductCategoryId = productCategoryId };
                case ProductCategoryDictionary.GPU:
                    return new GraphicsProcessingUnitCreateFormViewModel { ProductCategoryId = productCategoryId };
                case ProductCategoryDictionary.HDD:
                    return new HardDiskDriveCreateFormViewModel { ProductCategoryId = productCategoryId };
                case ProductCategoryDictionary.Motherboard:
                    return new MotherboardCreateFormViewModel { ProductCategoryId = productCategoryId };
                case ProductCategoryDictionary.PSU:
                    return new PowerSupplyUnitCreateFormViewModel { ProductCategoryId = productCategoryId };
                case ProductCategoryDictionary.RAM:
                    return new RandomAccessMemoryCreateFormViewModel { ProductCategoryId = productCategoryId };
                case ProductCategoryDictionary.SSD:
                    return new SolidStateDriveCreateFormViewModel { ProductCategoryId = productCategoryId };
                default:
                    return null;
            }
        }

        private Product MapNewProductViewModelToSpecificProduct(ProductCreateFormViewModel newProduct)
        {
            switch (newProduct.ProductCategoryId)
            {
                case ProductCategoryDictionary.CPU:
                    return mapper.Map<CentralProcessingUnit>(newProduct);
                case ProductCategoryDictionary.GPU:
                    return mapper.Map<GraphicsProcessingUnit>(newProduct);
                case ProductCategoryDictionary.HDD:
                    return mapper.Map<HardDiskDrive>(newProduct);
                case ProductCategoryDictionary.Motherboard:
                    return mapper.Map<Motherboard>(newProduct);
                case ProductCategoryDictionary.PSU:
                    return mapper.Map<PowerSupplyUnit>(newProduct);
                case ProductCategoryDictionary.RAM:
                    return mapper.Map<RandomAccessMemory>(newProduct);
                case ProductCategoryDictionary.SSD:
                    return mapper.Map<SolidStateDrive>(newProduct);
                default:
                    return null;
            }
        }

        private ProductDetailsViewModel MapProductToSpecificDetailsViewModel(Product product)
        {
            switch (product.ProductCategoryId)
            {
                case ProductCategoryDictionary.CPU:
                    return mapper.Map<CentralProcessingUnitDetailsViewModel>(product);
                case ProductCategoryDictionary.GPU:
                    return mapper.Map<GraphicsProcessingUnitDetailsViewModel>(product);
                case ProductCategoryDictionary.HDD:
                    return mapper.Map<HardDiskDriveDetailsViewModel>(product);
                case ProductCategoryDictionary.Motherboard:
                    return mapper.Map<MotherboardDetailsViewModel>(product);
                case ProductCategoryDictionary.PSU:
                    return mapper.Map<PowerSupplyUnitDetailsViewModel>(product);
                case ProductCategoryDictionary.RAM:
                    return mapper.Map<RandomAccessMemoryDetailsViewModel>(product);
                case ProductCategoryDictionary.SSD:
                    return mapper.Map<SolidStateDriveDetailsViewModel>(product);
                default:
                    return null;
            }
        }

        private ProductEditFormViewModel MapProductToSpceificEditFormViewModel(Product product)
        {
            switch (product.ProductCategoryId)
            {
                case ProductCategoryDictionary.CPU:
                    return mapper.Map<CentralProcessingUnitEditFormViewModel>(product);
                case ProductCategoryDictionary.GPU:
                    return mapper.Map<GraphicsProcessingUnitEditFormViewModel>(product);
                case ProductCategoryDictionary.HDD:
                    return mapper.Map<HardDiskDriveEditFormViewModel>(product);
                case ProductCategoryDictionary.Motherboard:
                    return mapper.Map<MotherboardEditFormViewModel>(product);
                case ProductCategoryDictionary.PSU:
                    return mapper.Map<PowerSupplyUnitEditFormViewModel>(product);
                case ProductCategoryDictionary.RAM:
                    return mapper.Map<RandomAccessMemoryEditFormViewModel>(product);
                case ProductCategoryDictionary.SSD:
                    return mapper.Map<SolidStateDriveEditFormViewModel>(product);
                default:
                    return null;
            }
        }

        private Product MapProductEditFormViewModelToConcreteProduct(ProductEditFormViewModel productDetailsViewModel)
        {
            switch (productDetailsViewModel.ProductCategoryId)
            {
                case ProductCategoryDictionary.CPU:
                    return mapper.Map<CentralProcessingUnit>(productDetailsViewModel);
                case ProductCategoryDictionary.GPU:
                    return mapper.Map<GraphicsProcessingUnit>(productDetailsViewModel);
                case ProductCategoryDictionary.HDD:
                    return mapper.Map<HardDiskDrive>(productDetailsViewModel);
                case ProductCategoryDictionary.Motherboard:
                    return mapper.Map<Motherboard>(productDetailsViewModel);
                case ProductCategoryDictionary.PSU:
                    return mapper.Map<PowerSupplyUnit>(productDetailsViewModel);
                case ProductCategoryDictionary.RAM:
                    return mapper.Map<RandomAccessMemory>(productDetailsViewModel);
                case ProductCategoryDictionary.SSD:
                    return mapper.Map<SolidStateDrive>(productDetailsViewModel);
                default:
                    return null;

            }
        }
    }
}
