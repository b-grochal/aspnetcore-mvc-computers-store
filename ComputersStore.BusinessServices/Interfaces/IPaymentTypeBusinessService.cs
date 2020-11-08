using ComputersStore.Models.ViewModels.PaymentType.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IPaymentTypeBusinessService
    {
        Task<IEnumerable<PaymentTypeViewModel>> GetPaymentTypesCollection();
    }
}
