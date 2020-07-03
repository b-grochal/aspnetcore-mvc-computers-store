using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IOrderBusinessService
    {
        IEnumerable<OrderViewModel> GetOrdersCollection(int? orderId, string userEmail, int? orderStatusId, int pageNumber, int pageSize);
        OrderDetailsViewModel GetOrder(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
