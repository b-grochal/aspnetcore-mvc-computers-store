using ComputersStore.Core.Data;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Implementation
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly ApplicationDbContext applicatioDbContext;

        public OrderStatusService(ApplicationDbContext applicatioDbContext)
        {
            this.applicatioDbContext = applicatioDbContext;
        }

        public async Task<IEnumerable<OrderStatus>> GetOrdersStatusCollection()
        {
             return await applicatioDbContext.OrderStatuses.ToListAsync();
        }
    }
}
