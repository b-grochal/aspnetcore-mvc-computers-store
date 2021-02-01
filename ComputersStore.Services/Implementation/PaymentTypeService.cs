using ComputersStore.Data.Entities;
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
        #region Fields

        private readonly ApplicationDbContext applicationDbContext;

        #endregion Fields

        #region Constructors

        public PaymentTypeService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        #endregion Constructors

        #region Public methods

        public async Task<IEnumerable<PaymentType>> GetPaymentTypesCollection()
        {
            return await applicationDbContext.PaymentTypes.ToListAsync();
        }

        #endregion Public methodss
    }
}
