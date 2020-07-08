using ComputersStore.Core.Data;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Implementation
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public PaymentTypeService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<PaymentType>> GetPaymentTypesCollection()
        {
            return await applicationDbContext.PaymentTypes.ToListAsync();
        }
    }
}
