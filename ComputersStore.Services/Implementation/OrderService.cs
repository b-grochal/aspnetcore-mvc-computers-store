using ComputersStore.Core.Data;
using ComputersStore.Data;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputersStore.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int orderId)
        {
            return applicationDbContext.Orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public IEnumerable<Order> GetOrdersCollection()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersCollection(int? orderId, string userEmail, OrderStatus? orderStatus, int pageNumber, int pageSize)
        {
            return applicationDbContext.Orders
                .Where(o => orderId == null || o.OrderId == orderId)
                .Where(o => userEmail == null || o.ApplicationUser.Email == userEmail)
                .Where(o => orderStatus == null || o.OrderStatus == orderStatus)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public void UpdateOrder(Order order)
        {
            applicationDbContext.Orders.Update(order);
            applicationDbContext.SaveChanges();
        }
    }
}
