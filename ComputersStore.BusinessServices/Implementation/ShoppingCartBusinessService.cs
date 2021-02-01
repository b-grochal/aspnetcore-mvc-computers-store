using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.ShoppingCart.Base;
using ComputersStore.Models.ViewModels.ShoppingCart.Complex;
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

        public async Task<ShoppingCartViewModel> PrepareShoppingCardData(ShoppingCart shoppingCart)
        {
            
            return new ShoppingCartViewModel
            {
                ShoppingCartItems = await PrepareShoppingCartItemsData(shoppingCart.GetShoppingCartItems())
            };
        }

        public async Task<int> SubmitOrder(string applicationUserId, ShoppingCart shoppingCart, SubmitOrderDetailsViewModel submitOrderDetailsViewModel)
        {
            var shoppingCartItems = await PrepareShoppingCartItemsData(shoppingCart.GetShoppingCartItems());
            var order = mapper.Map<Order>(submitOrderDetailsViewModel);
            order = mapper.Map(shoppingCart, order);
            order.ApplicationUserId = applicationUserId;
            order.TotalCost = shoppingCartItems.Sum(x => x.ProductPrice * x.Quantity);
            return await orderService.CreateOrder(order);
        }

        #endregion Public methods

        #region Private methods

        private async Task<IEnumerable<ShoppingCartItemViewModel>> PrepareShoppingCartItemsData(IEnumerable<ShoppingCartItem> shoppingCartItems)
        {
            var products = await productsService.GetProductsCollection(shoppingCartItems.Select(x => x.ProductId));
            var shoppingCartItemsViewModels = mapper.Map<IEnumerable<ShoppingCartItemViewModel>>(products);
            for(int i = 0; i < shoppingCartItemsViewModels.Count(); i++)
            {
                shoppingCartItemsViewModels.ElementAt(i).Quantity = shoppingCartItems.ElementAt(i).Quantity;
            }
            return shoppingCartItemsViewModels;
        }

        #endregion Private methods
    }
}
