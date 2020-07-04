using AutoMapper;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.OrderStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.Mappings
{
    public class OrderStatusMappingProfile : Profile
    {
        public OrderStatusMappingProfile()
        {
            CreateMap<OrderStatus, OrderStatusViewModel>();
        }
    }
}
