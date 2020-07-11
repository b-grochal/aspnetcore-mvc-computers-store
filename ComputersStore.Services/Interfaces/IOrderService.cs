using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersCollection();
        Task<IEnumerable<Order>> GetOrdersCollection(int? orderId, string userEmail, int? orderStatusId, int pageNumber, int pageSize);
        Task<Order> GetOrder(int orderId);
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int orderId);
    }
}
