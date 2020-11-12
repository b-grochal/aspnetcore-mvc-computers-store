using ComputersStore.Data.Entities;
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
        #region Fields

        private readonly ApplicationDbContext applicatioDbContext;

        #endregion Fields

        #region Constructors

        public OrderStatusService(ApplicationDbContext applicatioDbContext)
        {
            this.applicatioDbContext = applicatioDbContext;
        }

        #endregion Constructors

        #region Public methods

        public async Task<IEnumerable<OrderStatus>> GetOrderStatusesCollection()
        {
             return await applicatioDbContext.OrderStatuses.ToListAsync();
        }

        #endregion Public methods
    }
}
