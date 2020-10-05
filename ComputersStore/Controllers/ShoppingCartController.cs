﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.ShoppingCart;
using ComputersStore.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComputersStore.WebUI.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartBusinessService shoppingCartBusinessService;
        private readonly IPaymentTypeBusinessService paymentTypeBusinessService;
        public ShoppingCartController(IShoppingCartBusinessService shoppingCartBusinessService, IPaymentTypeBusinessService paymentTypeBusinessService)
        {
            this.shoppingCartBusinessService = shoppingCartBusinessService;
            this.paymentTypeBusinessService = paymentTypeBusinessService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Summary()
        {
            var shoppingCart = GetShoppingCart();
            var result = await shoppingCartBusinessService.GetProductsForShoppingCart(shoppingCart);
            return View(result);
        }

        public IActionResult AddProductToShoppingCart(int productId, string returnUrl, int quantity)
        {
            ShoppingCart shoppingCart = GetShoppingCart();
            shoppingCart.AddItem(productId, quantity);
            SaveShoppingCart(shoppingCart);
            return RedirectToAction(nameof(Summary));
        }

        public IActionResult RemoveProductFromShoppingCart(int productId)
        {
            ShoppingCart shoppingCart = GetShoppingCart();
            shoppingCart.RemoweItem(productId);
            SaveShoppingCart(shoppingCart);
            return RedirectToAction("Summary");
        }

        public async Task<IActionResult> SubmitOrder()
        {
            await PopulateUpdateFormSelectElements();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitOrder(SubmitOrderDetailsViewModel submitOrderDetailsViewModel)
        {
            var shoppingCart = GetShoppingCart();
            await shoppingCartBusinessService.SubmitOrder(GetCurrentUserId(), shoppingCart, submitOrderDetailsViewModel);
            return View("SubmitOrderSummary");
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

        private async Task PopulateUpdateFormSelectElements()
        {
            var paymentTypes = await paymentTypeBusinessService.GetPaymentTypesCollection();
            ViewData["PaymentTypes"] = new SelectList(paymentTypes, "PaymentTypeId", "Name");
        }

        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}