using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.PaymentType;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class PaymentTypeBusinessService : IPaymentTypeBusinessService
    {
        private readonly IPaymentTypeService paymentTypeService;
        private readonly IMapper mapper;

        public PaymentTypeBusinessService(IPaymentTypeService paymentTypeService, IMapper mapper)
        {
            this.paymentTypeService = paymentTypeService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PaymentTypeViewModel>> GetPaymentTypesCollection()
        {
            var paymentTypes = await paymentTypeService.GetPaymentTypesCollection();
            var result = mapper.Map<IEnumerable<PaymentTypeViewModel>>(paymentTypes);
            return result;
        }
    }
}
