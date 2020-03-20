using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels;
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

        public IEnumerable<ProductViewModel> GetProductsCollection()
        {
            var products = productService.GetProductsCollection();
            var result = mapper.Map<IEnumerable<ProductViewModel>>(products);
            return result;
        }

        public IEnumerable<ProductViewModel> GetProductsCollection(ProductCategory productCategory, int pageNumber, int pageSize)
        {

            var products = productService.GetProductsCollection(productCategory, pageNumber, pageSize);
            var result = mapper.Map<IEnumerable<ProductViewModel>>(products);
            return result;
        }
    }
}
