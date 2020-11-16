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
        Task DeleteApplicationUser(string applicationUserId);
        Task<ApplicationUser> GetApplicationUserById(string applicationUserId);
        Task<ApplicationUser> GetApplicationUserByEmail(string applicationUserEmail);
        Task<IEnumerable<ApplicationUser>> GetApplicationUsersCollection(string roleName, string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize);
        Task<int> GetApplicationUsersCollectionCount(string roleName, string firstName, string lastName, string email, string phoneNumber);
        Task<IEnumerable<string>> GetApplicationUsersEmailsCollection(string roleName); 
    }
}
