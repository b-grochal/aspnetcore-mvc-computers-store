using ComputersStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface IPaymentTypeService
    {
        Task<IEnumerable<PaymentType>> GetPaymentTypesCollection();
    }
}
