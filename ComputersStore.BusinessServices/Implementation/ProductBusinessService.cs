using ComputersStore.BusinessServices.Interfaces;
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
        public ProductBusinessService(IProductService productService)
        {
            this.productService = productService;
        }

        public IEnumerable<ProductViewModel> GetProductsCollection()
        {
            throw new NotImplementedException();
        }
    }
}
