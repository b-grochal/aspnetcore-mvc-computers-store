using ComputersStore.Models.ViewModels.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IApplicationUserBusinessService
    {
        Task<ApplicationUserViewModel> GetApplicationUserById(string applicationUserId);
        Task<ApplicationUserViewModel> GetApplicationUserByEmail(string applicationUserEmail);
        Task<ApplicationUsersCollectionViewModel> GetUsersCollection(string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize);
        Task<ApplicationUsersCollectionViewModel> GetAdminsCollection(string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize);
    }
}
