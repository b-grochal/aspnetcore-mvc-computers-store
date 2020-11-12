using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.ApplicationUser.Base;
using ComputersStore.Models.ViewModels.ApplicationUser.Complex;
using ComputersStore.Models.ViewModels.Other;
using ComputersStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class ApplicationUserBusinessService : IApplicationUserBusinessService
    {
        #region Fields

        private readonly IApplicationUserService applicationUserService;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        public ApplicationUserBusinessService(IApplicationUserService applicationUserService, IMapper mapper)
        {
            this.applicationUserService = applicationUserService;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Public methods

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

        public async Task<ApplicationUsersFilteredCollectionViewModel> GetApplicationUsersCollection(string roleName, string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize)
        {
            var applicationUsers = await applicationUserService.GetApplicationUsersCollection(roleName, firstName, lastName, email, phoneNumber, pageNumber, pageSize);
            var applicationUsersViewModels = mapper.Map<IEnumerable<ApplicationUserViewModel>>(applicationUsers);
            return new ApplicationUsersFilteredCollectionViewModel
            {
                ApplicationUsers = applicationUsersViewModels,
                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = pageSize,
                    TotalItems = await applicationUserService.GetApplicationUsersCollectionCount(roleName)
                },
                FirstNameFilteringParameter = firstName,
                LastNameFilteringParameter = lastName,
                EmailFilteringParameter = email,
                PhoneNumberFilteringParameter = phoneNumber
            };
        }

        public async Task DeleteApplicationUser(string applicationUserId)
        {
            await applicationUserService.DeleteApplicationUser(applicationUserId);
        }

        public async Task<IEnumerable<string>> GetApplicationUsersEmailsCollection(string roleName)
        {
            return await applicationUserService.GetApplicationUsersEmailsCollection(roleName);
        }

        #endregion Public methods
    }
}
