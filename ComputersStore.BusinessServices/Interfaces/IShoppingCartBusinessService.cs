using ComputersStore.Models.ViewModels.ShoppingCart.Base;
using ComputersStore.Models.ViewModels.ShoppingCart.Complex;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IShoppingCartBusinessService
    {
        Task<ShoppingCartViewModel> PrepareShoppingCardData(ShoppingCart shoppingCart);
        Task<int> SubmitOrder(string applicationUserId, ShoppingCart shoppingCart, SubmitOrderDetailsViewModel submitOrderDetailsViewModel);
    }
}
