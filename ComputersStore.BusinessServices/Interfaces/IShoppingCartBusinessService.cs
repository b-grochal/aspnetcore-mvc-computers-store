﻿using ComputersStore.Models.ViewModels.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IShoppingCartBusinessService
    {
        Task<IEnumerable<ShoppingCartItemViewModel>> GetProductsForShoppingCart(ShoppingCart shoppingCart);
        Task SubmitOrder(ShoppingCart shoppingCart, SubmitOrderDetailsViewModel submitOrderDetailsViewModel);
    }
}