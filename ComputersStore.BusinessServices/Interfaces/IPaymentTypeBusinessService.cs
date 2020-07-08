using ComputersStore.Models.ViewModels.PaymentType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IPaymentTypeBusinessService
    {
        Task<IEnumerable<PaymentTypeViewModel>> GetPaymentTypesCollection();
    }
}
