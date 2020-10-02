using System;
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

namespace ComputersStore.WebUI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderBusinessService orderBusinessService;
        private readonly IOrderStatusBusinessService orderStatusBusinessService;
        private readonly IPaymentTypeBusinessService paymentTypeBusinessService;
        private readonly int ordersPerPage = 5;

        public OrdersController(IOrderBusinessService orderBusinessService, IOrderStatusBusinessService orderStatusBusinessService, IPaymentTypeBusinessService paymentTypeBusinessService)
        {
            this.orderBusinessService = orderBusinessService;
            this.orderStatusBusinessService = orderStatusBusinessService;
            this.paymentTypeBusinessService = paymentTypeBusinessService;
        }

        public async Task<IActionResult> Table(int? orderId, int? orderStatusId, int? paymentTypeId, string applicationUserEmail, int pageNumber = 1)
        {
            var orders = await orderBusinessService.GetOrdersCollection(orderId, orderStatusId, paymentTypeId, applicationUserEmail, pageNumber, ordersPerPage, ordersPerPage);
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

        //// GET: Orders/Create
        //public IActionResult Create()
        //{
        //    ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
        //    return View();
        //}

        //// POST: Orders/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("OrderId,ApplicationUserId,OrderDate,ShipAddress,ShipCity,ShipPostalCode,ShipCountry,OrderStatus,PaymentType")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(order);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", order.ApplicationUserId);
        //    return View(order);
        //}

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderBusinessService.GetOrderEditFormData(id.Value);
            
            if (order == null)
            {
                return NotFound();
            }

            await PopulateUpdateFormSelectElements(order.OrderStatusId, order.PaymentTypeId);
            
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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

        // GET: Orders/Delete/5
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

            return PartialView("_DeleteOrderModalPartial", order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await orderBusinessService.DeleteOrder(id);
            return RedirectToAction(nameof(Table));
        }

        private async Task PopulateUpdateFormSelectElements(int? orderStatusId, int? paymentTypeId)
        {
            var orderStatuses = await orderStatusBusinessService.GetOrderStatusesCollection();
            var paymentTypes = await paymentTypeBusinessService.GetPaymentTypesCollection();
            ViewData["OrderStatuses"] = new SelectList(orderStatuses, "OrderStatusId", "Name", orderStatusId);
            ViewData["PaymentTypes"] = new SelectList(paymentTypes, "PaymentTypeId", "Name", paymentTypeId);
        }
    }
}
