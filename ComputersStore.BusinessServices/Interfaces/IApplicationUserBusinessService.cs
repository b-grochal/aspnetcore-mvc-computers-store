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
    }
}
