﻿using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.ApplicationUser;
using ComputersStore.Models.ViewModels.Order;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrder(int orderId)
        {
            await orderService.DeleteOrder(orderId);
        }

        public async Task<OrderViewModel> GetOrder(int orderId)
        {
            var order = await orderService.GetOrder(orderId);
            var result = mapper.Map<OrderViewModel>(order);
            return result;
        }

        public async Task<OrderDetailsViewModel> GetOrderDetails(int orderId)
        {
            var order = await orderService.GetOrder(orderId);
            var result = new OrderDetailsViewModel //TODO mapper do tworzenia viewmodelu
            {
                OrderViewModel = mapper.Map<OrderViewModel>(order),
                ApplicationUserViewModel = mapper.Map<ApplicationUserViewModel>(order.ApplicationUser),
                OrderItemsViewModel = mapper.Map<OrderItemViewModel[]>(order.OrderItems)
            };
            return result;
        }

        public async Task<OrderEditFormViewModel> GetOrderEditFormData(int orderId)
        {
            var order = await orderService.GetOrder(orderId);
            var result = mapper.Map<OrderEditFormViewModel>(order);
            return result;
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrdersCollection(int? orderId, string applicationUserEmail, int? orderStatusId, int pageNumber, int pageSize)
        {
            var orders = await orderService.GetOrdersCollection(orderId, applicationUserEmail, orderStatusId, pageNumber, pageSize);
            var result = mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return result;
        }

        public async Task UpdateOrder(OrderEditFormViewModel orderEditFormViewModel)
        {
            var order = await orderService.GetOrder(orderEditFormViewModel.OrderId);
            var updatedOrder = mapper.Map(orderEditFormViewModel, order);
            await orderService.UpdateOrder(updatedOrder);
        }
    }
}