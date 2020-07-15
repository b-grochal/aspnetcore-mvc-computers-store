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

        public async Task<IdentityUser> GetApplicationUser(string applicationUserId)
        {
            return await userManager.FindByIdAsync(applicationUserId);
        }

        public async Task<IEnumerable<ApplicationUser>> GetApplicationUsersCollection()
        {
            return await userManager.Users.ToListAsync();
        }
    }
}
