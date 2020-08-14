using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.ShoppingCart;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class ShoppingCartBusinessService : IShoppingCartBusinessService
    {
        private readonly IProductService productsService;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public ShoppingCartBusinessService(IProductService productsService, IOrderService orderService, IMapper mapper)
        {
            this.productsService = productsService;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ShoppingCartItemViewModel>> GetProductsForShoppingCart(ShoppingCart shoppingCart)
        {
            var products = await productsService.GetProductsCollectionById(shoppingCart.GetShoppingCartItems().Select(x => x.ProductId));
            var shoppingCartItemsViewModels = mapper.Map<IEnumerable<ShoppingCartItemViewModel>>(products);
            return UpdateShoppingCartItemsQuantities(shoppingCartItemsViewModels, shoppingCart.GetShoppingCartItems());
        }

        public Task SubmitOrder(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ShoppingCartItemViewModel> UpdateShoppingCartItemsQuantities(IEnumerable<ShoppingCartItemViewModel> shoppingCartItemViewModels, IEnumerable<ShoppingCartItem> shoppingCartItems)
        {
            for(int i = 0; i < shoppingCartItemViewModels.Count(); i++)
            {
                shoppingCartItemViewModels.ElementAt(i).Quantity = shoppingCartItems.ElementAt(i).Quantity;
            }
            return shoppingCartItemViewModels;
        }
    }
}
