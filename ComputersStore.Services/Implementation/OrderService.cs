using ComputersStore.Core.Data;
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

        public async Task AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrder(int orderId)
        {
            var order = await applicationDbContext.Orders.FindAsync(orderId);
            applicationDbContext.Orders.Remove(order);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await applicationDbContext.Orders
                .FirstOrDefaultAsync(x => x.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersCollection()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetOrdersCollection(int? orderId, string userEmail, int? orderStatusId, int pageNumber, int pageSize)
        {
            return await applicationDbContext.Orders
                .Where(o => orderId == null || o.OrderId == orderId)
                .Where(o => userEmail == null || o.ApplicationUser.Email == userEmail)
                .Where(o => orderStatusId == null || o.OrderStatusId == orderStatusId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            applicationDbContext.Orders.Update(order);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
