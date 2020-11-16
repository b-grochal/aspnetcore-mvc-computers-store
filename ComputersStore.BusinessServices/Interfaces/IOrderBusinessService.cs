using ComputersStore.Models.ViewModels.Order.Base;
using ComputersStore.Models.ViewModels.Order.Complex;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IOrderBusinessService
    {
        Task<OrdersFilteredCollectionViewModel> GetOrdersFilteredCollection(int? orderId, int? orderStatusId, int? paymentTypeId, string applicationUserEmail, int pageNumber, int pageSize, int ordersPerPage);
        Task<OrderViewModel> GetOrder(int orderId);
        Task<OrderDetailsViewModel> GetOrderDetails(int orderId);
        Task<OrderEditFormViewModel> GetOrderEditData(int orderId);
        Task UpdateOrder(OrderEditFormViewModel orderEditFormViewModel);
        Task DeleteOrder(int orderId);
        Task<OrdersCollectionViewModel> GetOrdersCollection(string applicationUserId);
        Task UpdateOrderStatus(int orderId, int newOrderStatusId);
    }
}
