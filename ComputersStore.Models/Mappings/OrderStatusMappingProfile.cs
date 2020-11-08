using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.OrderStatus.Base;

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
