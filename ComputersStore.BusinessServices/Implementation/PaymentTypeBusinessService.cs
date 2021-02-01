using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.PaymentType.Base;
using ComputersStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class PaymentTypeBusinessService : IPaymentTypeBusinessService
    {
        #region Fields

        private readonly IPaymentTypeService paymentTypeService;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        public PaymentTypeBusinessService(IPaymentTypeService paymentTypeService, IMapper mapper)
        {
            this.paymentTypeService = paymentTypeService;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Public methods

        public async Task<IEnumerable<PaymentTypeViewModel>> GetPaymentTypesCollection()
        {
            var paymentTypes = await paymentTypeService.GetPaymentTypesCollection();
            var result = mapper.Map<IEnumerable<PaymentTypeViewModel>>(paymentTypes);
            return result;
        }

        #endregion Public methods
    }
}
