using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.PaymentType;
using System;
using System.Collections.Generic;
using System.Text;

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
