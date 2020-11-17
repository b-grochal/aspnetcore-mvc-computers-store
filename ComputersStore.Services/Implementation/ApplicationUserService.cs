using ComputersStore.Data.Entities;
using ComputersStore.Data;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputersStore.Data.Dictionaries;

namespace ComputersStore.Services.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        #region Fields

        private readonly UserManager<ApplicationUser> userManager;

        #endregion Fields

        #region Constructors

        public ApplicationUserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        #endregion Constructors

        #region Public methods

        public async Task DeleteApplicationUser(string applicationUserId)
        {
            var applicationUser = await userManager.FindByIdAsync(applicationUserId);
            await userManager.DeleteAsync(applicationUser);
        }

        public async Task<ApplicationUser> GetApplicationUserById(string applicationUserId)
        {
            return await userManager.FindByIdAsync(applicationUserId);
        }

        public async Task<ApplicationUser> GetApplicationUserByEmail(string applicationUserEmail)
        {
            return await userManager.FindByEmailAsync(applicationUserEmail);
        }

        public async Task<IEnumerable<ApplicationUser>> GetApplicationUsersCollection(string roleName, string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize)
        {
            var users = await userManager.GetUsersInRoleAsync(roleName);
            return users
                .Where(u => firstName == null || u.FirstName == firstName)
                .Where(u => lastName == null || u.LastName == lastName)
                .Where(u => email == null || u.Email == email)
                .Where(u => phoneNumber == null || u.PhoneNumber == phoneNumber)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public async Task<int> GetApplicationUsersCollectionCount(string roleName, string firstName, string lastName, string email, string phoneNumber)
        {
            var users = await userManager.GetUsersInRoleAsync(roleName);
            return users
                .Where(u => firstName == null || u.FirstName == firstName)
                .Where(u => lastName == null || u.LastName == lastName)
                .Where(u => email == null || u.Email == email)
                .Where(u => phoneNumber == null || u.PhoneNumber == phoneNumber)
                .Count();
        }

        public async Task<IEnumerable<string>> GetApplicationUsersEmailsCollection(string roleName)
        {
            var admins = await userManager.GetUsersInRoleAsync(roleName);
            return admins.Select(a => a.Email);
        }

        #endregion Public methods
    }
}
