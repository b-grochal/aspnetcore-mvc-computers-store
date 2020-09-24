using ComputersStore.Data.Entities;
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
        Task<IEnumerable<ApplicationUser>> GetUsersCollection(string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize);
        Task<IEnumerable<ApplicationUser>> GetAdminsCollection(string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize);
        Task<int> GetUsersCollectionCount();
        Task<int> GetAdminsCollectionCount();
    }
}
