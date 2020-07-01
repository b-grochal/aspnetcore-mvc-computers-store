using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrdersCollection();
        IEnumerable<Order> GetOrdersCollection(int? orderId, string userEmail, OrderStatus? orderStatus, int pageNumber, int pageSize);
        Order GetOrder(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
