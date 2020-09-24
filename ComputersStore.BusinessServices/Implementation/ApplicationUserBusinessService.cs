using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.SearchCriteria.ApplicationUser;
using ComputersStore.Models.ViewModels.ApplicationUser;
using ComputersStore.Models.ViewModels.Other;
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

        public async Task<ApplicationUsersCollectionViewModel> GetUsersCollection(string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize)
        {
            var users = await applicationUserService.GetUsersCollection(firstName, lastName, email, phoneNumber, pageNumber, pageSize);
            var usersViewModels = mapper.Map<IEnumerable<ApplicationUserViewModel>>(users);
            return new ApplicationUsersCollectionViewModel
            {
                applicationUsers = usersViewModels,
                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = pageSize,
                    TotalItems = await applicationUserService.GetUsersCollectionCount()
                },
                applicationUserSearchCriteria = new ApplicationUserSearchCriteria
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber
                }
            };
        }

        public async Task<ApplicationUsersCollectionViewModel> GetAdminsCollection(string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize)
        {
            var admins = await applicationUserService.GetAdminsCollection(firstName, lastName, email, phoneNumber, pageNumber, pageSize);
            var adminsViewModels = mapper.Map<IEnumerable<ApplicationUserViewModel>>(admins);
            return new ApplicationUsersCollectionViewModel
            {
                applicationUsers = adminsViewModels,
                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = pageSize,
                    TotalItems = await applicationUserService.GetAdminsCollectionCount()
                },
                applicationUserSearchCriteria = new ApplicationUserSearchCriteria
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber
                }
            };
        }
    }
}
