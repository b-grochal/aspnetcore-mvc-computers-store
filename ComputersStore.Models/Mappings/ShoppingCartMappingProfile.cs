﻿using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Data.Dictionaries;
using System;
using ComputersStore.Models.ViewModels.ShoppingCart.Base;

namespace ComputersStore.Models.Mappings
{
    public class ShoppingCartMappingProfile : Profile
    {
        public ShoppingCartMappingProfile()
        {
            CreateMap<Product, ShoppingCartItemViewModel>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price));

            CreateMap<SubmitOrderDetailsViewModel, Order>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.OrderStatusId, opt => opt.MapFrom(src => OrderStatusDictionary.New));

            CreateMap<ShoppingCartItem, OrderItem>();

            CreateMap<ShoppingCart, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.GetShoppingCartItems()));
        }
    }
}
