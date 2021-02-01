using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.OrderStatus.Base;
using ComputersStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class OrderStatusBusinessService : IOrderStatusBusinessService
    {
        #region Fields

        private readonly IOrderStatusService orderStatusService;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        public OrderStatusBusinessService(IOrderStatusService orderStatusService, IMapper mapper)
        {
            this.orderStatusService = orderStatusService;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Public methods

        public async Task<IEnumerable<OrderStatusViewModel>> GetOrderStatusesCollection()
        {
            var orderStatuses = await orderStatusService.GetOrderStatusesCollection();
            var result = mapper.Map<IEnumerable<OrderStatusViewModel>>(orderStatuses);
            return result;
        }

        #endregion Public methods
    }
}
