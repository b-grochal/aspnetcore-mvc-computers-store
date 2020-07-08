using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.OrderStatus;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class OrderStatusBusinessService : IOrderStatusBusinessService
    {
        private readonly IOrderStatusService orderStatusService;
        private readonly IMapper mapper;

        public OrderStatusBusinessService(IOrderStatusService orderStatusService, IMapper mapper)
        {
            this.orderStatusService = orderStatusService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OrderStatusViewModel>> GetOrderStatusesCollection()
        {
            var orderStatuses = await orderStatusService.GetOrderStatusesCollection();
            var result = mapper.Map<IEnumerable<OrderStatusViewModel>>(orderStatuses);
            return result;
        }
    }
}
