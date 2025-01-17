﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputersStore.Data.Entities;
using ComputersStore.Data;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Models.ViewModels.Order;
using ComputersStore.EmailHelper.Service.Interface;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ComputersStore.Data.Dictionaries;
using ComputersStore.Models.ViewModels.Order.Base;

namespace ComputersStore.WebUI.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        #region Fields

        private readonly IOrderBusinessService orderBusinessService;
        private readonly IOrderStatusBusinessService orderStatusBusinessService;
        private readonly IPaymentTypeBusinessService paymentTypeBusinessService;
        private readonly IApplicationUserBusinessService applicationUserBusinessService;
        private readonly IEmailService emailService;
        private readonly int ordersPerPage = 5;

        #endregion Fields

        #region Constructors

        public OrdersController(IOrderBusinessService orderBusinessService, IOrderStatusBusinessService orderStatusBusinessService, IPaymentTypeBusinessService paymentTypeBusinessService, IApplicationUserBusinessService applicationUserBusinessService, IEmailService emailService)
        {
            this.orderBusinessService = orderBusinessService;
            this.orderStatusBusinessService = orderStatusBusinessService;
            this.paymentTypeBusinessService = paymentTypeBusinessService;
            this.applicationUserBusinessService = applicationUserBusinessService;
            this.emailService = emailService;
        }

        #endregion Constructors 

        #region Actions

        // GET: Orders/Table
        [Authorize(Roles = ApplicationUserRoleDictionary.Admin)]
        public async Task<IActionResult> Table(int? orderId, int? orderStatusId, int? paymentTypeId, string applicationUserEmail, int pageNumber = 1)
        {
            var orders = await orderBusinessService.GetOrdersFilteredCollection(orderId, orderStatusId, paymentTypeId, applicationUserEmail, pageNumber, ordersPerPage, ordersPerPage);
            await PopulateUpdateFormSelectElements(orderStatusId, paymentTypeId);
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderBusinessService.GetOrderDetails(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = ApplicationUserRoleDictionary.Admin)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderBusinessService.GetOrderEditData(id.Value);
            
            if (order == null)
            {
                return NotFound();
            }

            await PopulateUpdateFormSelectElements(order.OrderStatusId, order.PaymentTypeId);
            
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [Authorize(Roles = ApplicationUserRoleDictionary.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderEditFormViewModel orderEditFormViewModel)
        {
            if (id != orderEditFormViewModel.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await orderBusinessService.UpdateOrder(orderEditFormViewModel);
                return RedirectToAction(nameof(Table));
            }
            await PopulateUpdateFormSelectElements(orderEditFormViewModel.OrderStatusId, orderEditFormViewModel.PaymentTypeId);
            return View(orderEditFormViewModel);
        }

        // GET: Orders/ChangeStatus/5
        [Authorize(Roles = ApplicationUserRoleDictionary.Admin)]
        public async Task<IActionResult> ChangeStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderBusinessService.GetOrder(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            await PopulateChangeOrdersStatusFormSelectElements(order.OrderStatusId);
            return PartialView("~/Views/Orders/Modals/_ChangeOrderStatusModal.cshtml" ,order);
        }

        // POST: Orders/ChangeStatus/5
        [HttpPost]
        [Authorize(Roles = ApplicationUserRoleDictionary.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus(int id, int orderStatusId)
        {
            await orderBusinessService.UpdateOrderStatus(id, orderStatusId);
            await SendOrderStatusChangedEmail(id);
            return Json( new { success = true });
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = ApplicationUserRoleDictionary.Admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderBusinessService.GetOrder(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/Orders/Modals/_DeleteOrderModal.cshtml", order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = ApplicationUserRoleDictionary.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await orderBusinessService.DeleteOrder(id);
            return RedirectToAction(nameof(Table));
        }

        #endregion Actions

        #region Helpers

        private async Task PopulateUpdateFormSelectElements(int? orderStatusId, int? paymentTypeId)
        {
            var orderStatuses = await orderStatusBusinessService.GetOrderStatusesCollection();
            var paymentTypes = await paymentTypeBusinessService.GetPaymentTypesCollection();
            ViewData["OrderStatuses"] = new SelectList(orderStatuses, "OrderStatusId", "Name", orderStatusId);
            ViewData["PaymentTypes"] = new SelectList(paymentTypes, "PaymentTypeId", "Name", paymentTypeId);
        }

        private async Task PopulateChangeOrdersStatusFormSelectElements(int? orderStatusId)
        {
            var orderStatuses = await orderStatusBusinessService.GetOrderStatusesCollection();
            ViewData["OrderStatuses"] = new SelectList(orderStatuses, "OrderStatusId", "Name", orderStatusId);
        }

        private async Task SendOrderStatusChangedEmail(int orderId)
        {
            var updatedOrder = await orderBusinessService.GetOrderDetails(orderId);
            await emailService.SendOrderStatusChangedEmail(updatedOrder.ApplicationUserViewModel.Email, updatedOrder.ApplicationUserViewModel.FirstName, updatedOrder.OrderViewModel.OrderId, updatedOrder.OrderViewModel.OrderStatusName);
        }

        #endregion Helpers

    }
}
