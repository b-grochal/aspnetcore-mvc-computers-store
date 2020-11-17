using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Data.Dictionaries;
using ComputersStore.EmailHelper.Service.Interface;
using ComputersStore.Models.ViewModels.ShoppingCart;
using ComputersStore.Models.ViewModels.ShoppingCart.Base;
using ComputersStore.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComputersStore.WebUI.Controllers
{
    [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
    public class ShoppingCartController : Controller
    {
        #region Fields

        private readonly IShoppingCartBusinessService shoppingCartBusinessService;
        private readonly IPaymentTypeBusinessService paymentTypeBusinessService;
        private readonly IApplicationUserBusinessService applicationUserBusinessService;
        private readonly IEmailService emailService;

        #endregion Fields

        #region Constructors

        public ShoppingCartController(IShoppingCartBusinessService shoppingCartBusinessService, IPaymentTypeBusinessService paymentTypeBusinessService, IApplicationUserBusinessService applicationUserBusinessService, IEmailService emailService)
        {
            this.shoppingCartBusinessService = shoppingCartBusinessService;
            this.paymentTypeBusinessService = paymentTypeBusinessService;
            this.applicationUserBusinessService = applicationUserBusinessService;
            this.emailService = emailService;
        }

        #endregion Constructors

        #region Actions

        // GET: ShoppingCart/Summary
        public async Task<IActionResult> Summary()
        {
            var shoppingCart = GetShoppingCart();
            var shoppingCartViewModel = await shoppingCartBusinessService.PrepareShoppingCardData(shoppingCart);
            return View(shoppingCartViewModel);
        }

        // POST: ShoppingCart/AddProductToShoppingCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProductToShoppingCart(int productId, int quantity)
        {
            ShoppingCart shoppingCart = GetShoppingCart();
            shoppingCart.AddItem(productId, quantity);
            SaveShoppingCart(shoppingCart);
            return RedirectToAction(nameof(Summary));
        }

        // POST: ShoppingCart/RemoveProductFromShoppingCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveProductFromShoppingCart(int productId)
        {
            ShoppingCart shoppingCart = GetShoppingCart();
            shoppingCart.RemoweItem(productId);
            SaveShoppingCart(shoppingCart);
            return RedirectToAction("Summary");
        }

        // GET: ShoppingCart/SubmitOrder
        public async Task<IActionResult> SubmitOrder()
        {
            await PopulateUpdateFormSelectElements();
            return View();
        }

        // POST: ShoppingCart/SubmitOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitOrder(SubmitOrderDetailsViewModel submitOrderDetailsViewModel)
        {
            var shoppingCart = GetShoppingCart();
            var newOrderId = await shoppingCartBusinessService.SubmitOrder(GetCurrentUserId(), shoppingCart, submitOrderDetailsViewModel);
            await SendNewOrderConfirmationEmail(newOrderId);
            RemoveShoppingCart();
            return View("SubmitOrderSummary");
        }

        #endregion Actions

        #region Helpers

        private ShoppingCart GetShoppingCart()
        {
            ShoppingCart cart = HttpContext.Session.GetJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();
            return cart;
        }

        private void SaveShoppingCart(ShoppingCart shoppingCart)
        {
            HttpContext.Session.SetJson("ShoppingCart", shoppingCart);
        }

        private void RemoveShoppingCart()
        {
            HttpContext.Session.Remove("ShoppingCart");
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

        private async Task SendNewOrderConfirmationEmail(int newOrderId)
        {
            var customer = await applicationUserBusinessService.GetApplicationUserById(GetCurrentUserId());
            await emailService.SendNewOrderAcceptanceConfirmationEmail(customer.Email, customer.FirstName, newOrderId);
        }

        #endregion Helpers
    }
}