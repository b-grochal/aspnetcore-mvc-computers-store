using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.PaymentType.Base;

namespace ComputersStore.Models.Mappings
{
    public class PaymentTypeMappingProfile : Profile
    {
        public PaymentTypeMappingProfile()
        {
            CreateMap<PaymentType, PaymentTypeViewModel>();
        }
    }
}
