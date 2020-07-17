﻿using ComputersStore.Core.Data;
using ComputersStore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        
        public AccountService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> Register(ApplicationUser applicationUser)
        {
            return await userManager.CreateAsync(applicationUser); 
        }

        public async Task<IdentityResult> ConfirmEmail(string applicationUserId, string code)
        {
            var applicationUser = await userManager.FindByIdAsync(applicationUserId);
            return await userManager.ConfirmEmailAsync(applicationUser, code);
        }

        public async Task<bool> IsEmailConfirmed(string applicationUserEmail)
        {
            var applicationUser = await userManager.FindByEmailAsync(applicationUserEmail);
            return (applicationUser == null || !(await userManager.IsEmailConfirmedAsync(applicationUser)));
        }

        public async Task<IdentityResult> ResetPassword(string applicationUserEmail, string code, string password)
        {
            var applicationUser = await userManager.FindByEmailAsync(applicationUserEmail);
            if(applicationUser == null)
            {
                return IdentityResult.Failed(); // TODO: Dodać info o errorze
            }
            return await userManager.ResetPasswordAsync(applicationUser, code, password);
        }

        public async Task<IdentityResult> ChangePassword(string applicationUserId, string oldPassword, string newPassword)
        {
            var applicationUser = await userManager.FindByIdAsync(applicationUserId);
            return await userManager.ChangePasswordAsync(applicationUser, oldPassword, newPassword);
        }

        public async Task<string> GenerateEmailConfirmationToken(string applicationUserId)
        {
            var applicationUser = await userManager.FindByIdAsync(applicationUserId);
            var token = await userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
            return token;
        }

        public async Task<ApplicationUser> GetApplicationUserById(string applicationUserId)
        {
            return await userManager.FindByIdAsync(applicationUserId);
        }

        public async Task<ApplicationUser> GetApplicationUserByEmail(string applicationUserEmail)
        {
            return await userManager.FindByEmailAsync(applicationUserEmail);
        }
    }
}
