using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.ApplicationUser.Base;
using ComputersStore.Models.ViewModels.Order.Base;
using ComputersStore.Models.ViewModels.Order.Complex;
using ComputersStore.Models.ViewModels.Other;
using ComputersStore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class OrderBusinessService : IOrderBusinessService
    {
        #region Fields

        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        public OrderBusinessService(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Public methods

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
            var result = new OrderDetailsViewModel
            {
                OrderViewModel = mapper.Map<OrderViewModel>(order),
                ApplicationUserViewModel = mapper.Map<ApplicationUserViewModel>(order.ApplicationUser),
                OrderItemsViewModel = mapper.Map<IEnumerable<OrderItemViewModel>>(order.OrderItems)
            };
            return result;
        }

        public async Task<OrderEditFormViewModel> GetOrderEditData(int orderId)
        {
            var order = await orderService.GetOrder(orderId);
            var result = mapper.Map<OrderEditFormViewModel>(order);
            return result;
        }

        public async Task<OrdersFilteredCollectionViewModel> GetOrdersCollection(int? orderId, int? orderStatusId, int? paymentTypeId, string applicationUserEmail, int pageNumber, int pageSize, int ordersPerPage)
        {
            var orders = await orderService.GetOrdersCollection(orderId, orderStatusId, paymentTypeId, applicationUserEmail, pageNumber, pageSize);
            var mappedOrders = mapper.Map<IEnumerable<OrderViewModel>>(orders);
            var result = new OrdersFilteredCollectionViewModel
            {
                Orders = mappedOrders,
                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = pageSize,
                    TotalItems = mappedOrders.Count()
                },
                OrderId = orderId,
                OrderStatusId = orderStatusId,
                PaymentTypeId = paymentTypeId,
                ApplicationUserEmail = applicationUserEmail
            };
            return result;
        }

        public async Task<OrdersCollectionViewModel> GetOrdersCollection(string applicationUserId)
        {
            var orders = await orderService.GetOrdersCollection(applicationUserId);
            var mappedOrders = mapper.Map<IEnumerable<OrderViewModel>>(orders);
            var result = new OrdersCollectionViewModel
            {
                Orders = mappedOrders
            };
            return result;
        }

        public async Task UpdateOrder(OrderEditFormViewModel orderEditFormViewModel)
        {
            var order = await orderService.GetOrder(orderEditFormViewModel.OrderId);
            var updatedOrder = mapper.Map(orderEditFormViewModel, order);
            await orderService.UpdateOrder(updatedOrder);
        }

        public async Task UpdateOrderStatus(int orderId, int newOrderStatusId)
        {
            await orderService.UpdateOrderStatus(orderId, newOrderStatusId);
        }

        #endregion Public methods
    }
}
