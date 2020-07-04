using ComputersStore.Models.ViewModels.OrderStatus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IOrderStatusBusinessService
    {
        Task<IEnumerable<OrderStatusViewModel>> GetOrdersStatusCollection();
    }
}
