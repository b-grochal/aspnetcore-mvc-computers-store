using ComputersStore.Models.ViewModels.ApplicationUser;
using ComputersStore.Models.ViewModels.ApplicationUser.Base;
using ComputersStore.Models.ViewModels.ApplicationUser.Complex;
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
        Task<ApplicationUsersFilteredCollectionViewModel> GetApplicationUsersCollection(string roleName, string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize);
        Task DeleteApplicationUser(string applicationUserId);
        Task<IEnumerable<string>> GetApplicationUsersEmailsCollection(string roleName);
    }
}
