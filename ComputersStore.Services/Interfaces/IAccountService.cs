﻿using ComputersStore.Core.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(ApplicationUser applicationUser);
        Task<IdentityResult> ConfirmEmail(string applicationUserId, string code);
        Task<bool> IsEmailConfirmed(string applicationUserEmail);
        Task<IdentityResult> ResetPassword(string applicationUserEmail, string code, string password);
        Task<IdentityResult> ChangePassword(string applicationUserId, string oldPassword, string newPassword);
        Task<string> GenerateEmailConfirmationToken(string applicationUserEmail);
        Task<ApplicationUser> GetApplicationUserById(string applicationUserId);
        Task<ApplicationUser> GetApplicationUserByEmail(string applicationUserEmail);
    }
}
