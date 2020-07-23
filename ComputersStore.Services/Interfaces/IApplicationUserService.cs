using ComputersStore.Core.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task CreateApplicationUser(ApplicationUser applicationUser);
        Task UpdateApplicationUser(ApplicationUser applicationUser);
        Task DeleteApplicationUser(string applicationUserId);
        Task<ApplicationUser> GetApplicationUserById(string applicationUserId);
        Task<ApplicationUser> GetApplicationUserByEmail(string applicationUserEmail);
        Task<IEnumerable<ApplicationUser>> GetApplicationUsersCollection();
    }
}
