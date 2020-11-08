using ComputersStore.Models.ViewModels.OrderStatus.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IOrderStatusBusinessService
    {
        Task<IEnumerable<OrderStatusViewModel>> GetOrderStatusesCollection();
    }
}
