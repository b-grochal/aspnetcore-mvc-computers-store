using ComputersStore.Core.Data;
using ComputersStore.Data;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<IdentityUser> userManager;
        public ApplicationUserService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Task<IdentityUser> GetApplicationUser(string applicationUserId)
        {
            return userManager.FindByIdAsync(applicationUserId);
        }
    }
}
