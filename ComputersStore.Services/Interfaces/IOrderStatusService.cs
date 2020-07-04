using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface IOrderStatusService
    {
       Task<IEnumerable<OrderStatus>> GetOrdersStatusCollection();
    }
}
