using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputersStore.Core.Data;
using ComputersStore.Data;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Models.ViewModels.Order;

namespace ComputersStore.WebUI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderBusinessService orderBusinessService;
        private readonly IOrderStatusBusinessService orderStatusBusinessService;
        private readonly IPaymentTypeBusinessService paymentTypeBusinessService;
        private readonly int ordersPerPage = 5;

        public OrdersController(ApplicationDbContext context, IOrderBusinessService orderBusinessService, IOrderStatusBusinessService orderStatusBusinessService, IPaymentTypeBusinessService paymentTypeBusinessService)
        {
            _context = context;
            this.orderBusinessService = orderBusinessService;
            this.orderStatusBusinessService = orderStatusBusinessService;
            this.paymentTypeBusinessService = paymentTypeBusinessService;
        }

        public async Task<IActionResult> List(int? orderId, string applicationUserId, int? orderStatusId, int pageNumber = 1)
        {
            var orders = await orderBusinessService.GetOrdersCollection(orderId, applicationUserId, orderStatusId, pageNumber, ordersPerPage);
            return View(orders);
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders.Include(o => o.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
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

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ApplicationUserId,OrderDate,ShipAddress,ShipCity,ShipPostalCode,ShipCountry,OrderStatus,PaymentType")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", order.ApplicationUserId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderBusinessService.GetOrderEditFormData(id.Value);
            await PopulateUpdateFormSelectElements(order.OrderStatusId, order.PaymentTypeId);
            if (order == null)
            {
                return NotFound();
            }
            
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
                try
                {
                    await orderBusinessService.UpdateOrder(orderEditFormViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(orderEditFormViewModel.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
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

            var order = await _context.Orders
                .Include(o => o.ApplicationUser)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }

        private async Task PopulateUpdateFormSelectElements(int orderStatusId, int paymentTypeId)
        {
            var orderStatuses = await orderStatusBusinessService.GetOrdersStatusCollection();
            var paymentTypes = await paymentTypeBusinessService.GetOrdersStatusCollection();
            ViewData["OrderStatuses"] = new SelectList(orderStatuses, "OrderStatusId", "Name", orderStatusId);
            ViewData["PaymentTypes"] = new SelectList(paymentTypes, "PaymentTypeId", "Name", paymentTypeId);
        }
    }
}
