﻿using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.Order;
using ComputersStore.Models.ViewModels.Order.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.Mappings
{
    public class OrdersMappingProfile : Profile
    {
        public OrdersMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.ApplicationUserEmail, opt => opt.MapFrom(src => src.ApplicationUser.Email))
                .ForMember(dest => dest.OrderStatusName, opt => opt.MapFrom(src => src.OrderStatus.Name))
                .ForMember(dest => dest.PaymentTypeName, opt => opt.MapFrom(src => src.PaymentType.Name));

            CreateMap<Order, OrderEditFormViewModel>()
                .ForMember(dest => dest.ApplicationUserEmail, opt => opt.MapFrom(src => src.ApplicationUser.Email));

            CreateMap<OrderEditFormViewModel, Order>();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price));
        }
    }
}
