using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.Basic;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.BusinessServices.Implementation
{
    public class ApplicationUserBusinessService : IApplicationUserBusinessService
    {
        private readonly IApplicationUserService applicationUserService;
        public ApplicationUserBusinessService()
        {

        }

        public ApplicationUserViewModel GetApplicationUser(string applicationUserId)
        {
            throw new NotImplementedException();
        }
    }
}
