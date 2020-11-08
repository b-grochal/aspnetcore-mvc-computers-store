using ComputersStore.Models.ViewModels.ShoppingCart.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IShoppingCartBusinessService
    {
        Task<IEnumerable<ShoppingCartItemViewModel>> GetProductsForShoppingCart(ShoppingCart shoppingCart);
        Task<int> SubmitOrder(string applicationUserId, ShoppingCart shoppingCart, SubmitOrderDetailsViewModel submitOrderDetailsViewModel);
    }
}
