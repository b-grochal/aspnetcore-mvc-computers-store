using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersStore.Models.ViewModels.ShoppingCart;
using ComputersStore.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ComputersStore.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public RedirectToActionResult AddProductToShoppingCart(int productId, string returnUrl)
        {
            ShoppingCart shoppingCart = GetShoppingCart();
            shoppingCart.AddItem(productId);
            SaveShoppingCart(shoppingCart);
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveProductFromShoppingCart(int productId, string returnUrl)
        {
            ShoppingCart shoppingCart = GetShoppingCart();
            shoppingCart.RemoweItem(productId);
            SaveShoppingCart(shoppingCart);
            return RedirectToAction("Index", new { returnUrl });
        }

        private ShoppingCart GetShoppingCart()
        {
            ShoppingCart cart = HttpContext.Session.GetJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();
            return cart;
        }

        private void SaveShoppingCart(ShoppingCart shoppingCart)
        {
            HttpContext.Session.SetJson("ShoppingCart", shoppingCart);
        }
    }
}