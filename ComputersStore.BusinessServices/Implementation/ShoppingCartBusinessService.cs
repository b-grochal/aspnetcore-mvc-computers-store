using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.ShoppingCart.Base;
using ComputersStore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class ShoppingCartBusinessService : IShoppingCartBusinessService
    {
        #region Fields

        private readonly IProductService productsService;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        public ShoppingCartBusinessService(IProductService productsService, IOrderService orderService, IMapper mapper)
        {
            this.productsService = productsService;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Public methods

        public async Task<IEnumerable<ShoppingCartItemViewModel>> GetProductsForShoppingCart(ShoppingCart shoppingCart)
        {
            var products = await productsService.GetProductsCollectionByIds(shoppingCart.GetShoppingCartItems().Select(x => x.ProductId));
            var shoppingCartItemsViewModels = mapper.Map<IEnumerable<ShoppingCartItemViewModel>>(products);
            return UpdateShoppingCartItemsQuantities(shoppingCartItemsViewModels, shoppingCart.GetShoppingCartItems());
        }

        public async Task<int> SubmitOrder(string applicationUserId, ShoppingCart shoppingCart, SubmitOrderDetailsViewModel submitOrderDetailsViewModel)
        {
            var ordersProducts = await GetProductsForShoppingCart(shoppingCart);
            var order = mapper.Map<Order>(submitOrderDetailsViewModel);
            order = mapper.Map(shoppingCart, order);
            order.ApplicationUserId = applicationUserId;
            order.TotalCost = ordersProducts.Sum(x => x.ProductPrice * x.Quantity);
            return await orderService.CreateOrder(order);
        }

        #endregion Public methods

        #region Private methods

        private IEnumerable<ShoppingCartItemViewModel> UpdateShoppingCartItemsQuantities(IEnumerable<ShoppingCartItemViewModel> shoppingCartItemViewModels, IEnumerable<ShoppingCartItem> shoppingCartItems)
        {
            for(int i = 0; i < shoppingCartItemViewModels.Count(); i++)
            {
                shoppingCartItemViewModels.ElementAt(i).Quantity = shoppingCartItems.ElementAt(i).Quantity;
            }
            return shoppingCartItemViewModels;
        }

        #endregion Private methods
    }
}
