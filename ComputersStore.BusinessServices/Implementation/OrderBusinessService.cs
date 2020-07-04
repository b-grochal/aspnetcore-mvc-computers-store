using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.ApplicationUser;
using ComputersStore.Models.ViewModels.Order;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.BusinessServices.Implementation
{
    public class OrderBusinessService : IOrderBusinessService
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrderBusinessService(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public OrderDetailsViewModel GetOrder(int orderId)
        {
            var order = orderService.GetOrder(orderId);
            var result = new OrderDetailsViewModel
            {
                OrderViewModel = mapper.Map<OrderViewModel>(order),
                ApplicationUserViewModel = mapper.Map<ApplicationUserViewModel>(order.ApplicationUser),
                OrderItemsViewModel = mapper.Map<OrderItemViewModel[]>(order.OrderItems)
            };
            return result;
        }

        public IEnumerable<OrderViewModel> GetOrdersCollection(int? orderId, string applicationUserEmail, int? orderStatusId, int pageNumber, int pageSize)
        {
            var orders = orderService.GetOrdersCollection(orderId, applicationUserEmail, orderStatusId, pageNumber, pageSize);
            var result = mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return result;
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
