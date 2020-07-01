using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<IdentityUser> GetApplicationUser(string applicationUserId);
    }
}
