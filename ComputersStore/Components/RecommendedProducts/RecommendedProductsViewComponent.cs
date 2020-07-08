using ComputersStore.BusinessServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputersStore.WebUI.Components.RecommendedProducts
{
    public class RecommendedProductsViewComponent : ViewComponent
    {
        private readonly IProductBusinessService productBusinessService;

        public RecommendedProductsViewComponent(IProductBusinessService productBusinessService)
        {
            this.productBusinessService = productBusinessService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var recommendedProducts = await productBusinessService.GetRecommendedProductsCollection(4);
            return View(recommendedProducts);
        }
    }
}
