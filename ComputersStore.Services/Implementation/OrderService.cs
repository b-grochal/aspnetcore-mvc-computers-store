using ComputersStore.Data.Entities;
using ComputersStore.Data;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task CreateOrder(Order order)
        {
            applicationDbContext.Orders.Add(order);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(int orderId)
        {
            var order = await applicationDbContext.Orders.FindAsync(orderId);
            applicationDbContext.Orders.Remove(order);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await applicationDbContext.Orders.FindAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersCollection()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetOrdersCollection(int? orderId, int? orderStatusId, int? paymentTypeId, string userEmail, int pageNumber, int pageSize)
        {
            return await applicationDbContext.Orders
                .Where(o => orderId == null || o.OrderId == orderId)
                .Where(o => orderStatusId == null || o.OrderStatusId == orderStatusId)
                .Where(o => paymentTypeId == null || o.PaymentTypeId == paymentTypeId)
                .Where(o => userEmail == null || o.ApplicationUser.Email == userEmail)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetApplicationUserOrdersCollection(string applicationUserId)
        {
            return await applicationDbContext.Orders
                .Where(o => o.ApplicationUserId == applicationUserId)
                .ToListAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            applicationDbContext.Orders.Update(order);
            await applicationDbContext.SaveChangesAsync();
        }

        private Order CalculateOrderTotalCost(Order order) 
        {
            order.TotalCost = order.OrderItems.Sum(i => i.Quantity * i.Product.Price);
            return order;
        }
    }
}
