using ComputersStore.Core.Data;
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

namespace ComputersStore.Services.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        public ApplicationUserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task CreateApplicationUser(ApplicationUser applicationUser)
        {
            await userManager.CreateAsync(applicationUser);
        }

        public async Task UpdateApplicationUser(ApplicationUser applicationUser)
        {
            await userManager.UpdateAsync(applicationUser);
        }

        public async Task DeleteApplicationUser(string applicationUserId)
        {
            var applicationUser = await userManager.FindByIdAsync(applicationUserId);
            await userManager.DeleteAsync(applicationUser);
        }

        public async Task<ApplicationUser> GetApplicationUserById(string applicationUserId)
        {
            return await userManager.FindByIdAsync(applicationUserId);
        }

        public async Task<IEnumerable<ApplicationUser>> GetApplicationUsersCollection()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetApplicationUserByEmail(string applicationUserEmail)
        {
            return await userManager.FindByEmailAsync(applicationUserEmail);
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersCollection(string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize)
        {
            var users = await userManager.GetUsersInRoleAsync("User");
            return users
                .Where(u => firstName == null || u.FirstName == firstName)
                .Where(u => lastName == null || u.LastName == lastName)
                .Where(u => email == null || u.Email == email)
                .Where(u => phoneNumber == null || u.PhoneNumber == phoneNumber)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAdminsCollection(string firstName, string lastName, string email, string phoneNumber, int pageNumber, int pageSize)
        {
            var admins = await userManager.GetUsersInRoleAsync("Admin");
            return admins
                .Where(u => firstName == null || u.FirstName == firstName)
                .Where(u => lastName == null || u.LastName == lastName)
                .Where(u => email == null || u.Email == email)
                .Where(u => phoneNumber == null || u.PhoneNumber == phoneNumber)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public async Task<int> GetUsersCollectionCount()
        {
            var users = await userManager.GetUsersInRoleAsync("Admin");
            return users.Count();
        }

        public async Task<int> GetAdminsCollectionCount()
        {
            var users = await userManager.GetUsersInRoleAsync("Admin");
            return users.Count();
        }
    }
}
