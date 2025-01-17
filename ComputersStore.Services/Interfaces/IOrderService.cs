﻿using ComputersStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersCollection(int? orderId, int? orderStatusId, int? paymentTypeId, string userEmail, int pageNumber, int pageSize);
        Task<int> GetOrdersCollectionCount(int? orderId, int? orderStatusId, int? paymentTypeId, string userEmail);
        Task<Order> GetOrder(int orderId);
        Task<int> CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int orderId);
        Task<IEnumerable<Order>> GetOrdersCollection(string applicationUserId);
        Task UpdateOrderStatus(int orderId, int newOrderStatusId);
    }
}
