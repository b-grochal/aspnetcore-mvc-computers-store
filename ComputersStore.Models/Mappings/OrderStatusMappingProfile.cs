using AutoMapper;
using ComputersStore.Data.Entities;
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
