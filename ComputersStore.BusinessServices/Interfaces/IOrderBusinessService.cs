using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IOrderBusinessService
    {
        Task<IEnumerable<OrderViewModel>> GetOrdersCollection(int? orderId, string userEmail, int? orderStatusId, int pageNumber, int pageSize);
        Task<OrderDetailsViewModel> GetOrderDetails(int orderId);
        Task<OrderEditFormViewModel> GetOrderEditFormData(int orderId);
        Task AddOrder(Order order);
        Task UpdateOrder(OrderEditFormViewModel orderEditFormViewModel);
        Task DeleteOrder(int orderId);
    }
}
