using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.ApplicationUser;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class ApplicationUserBusinessService : IApplicationUserBusinessService
    {
        private readonly IApplicationUserService applicationUserService;
        private readonly IMapper mapper;
        public ApplicationUserBusinessService(IApplicationUserService applicationUserService, IMapper mapper)
        {
            this.applicationUserService = applicationUserService;
            this.mapper = mapper;
        }

        public async Task<ApplicationUserViewModel> GetApplicationUserByEmail(string applicationUserEmail)
        {
            var applicationUser = await applicationUserService.GetApplicationUserByEmail(applicationUserEmail);
            var result = mapper.Map<ApplicationUserViewModel>(applicationUser);
            return result;
        }

        public async Task<ApplicationUserViewModel> GetApplicationUserById(string applicationUserId)
        {
            var applicationUser = await applicationUserService.GetApplicationUserById(applicationUserId);
            var result = mapper.Map<ApplicationUserViewModel>(applicationUser);
            return result;
        }
    }
}
