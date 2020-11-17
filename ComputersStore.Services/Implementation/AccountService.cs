using ComputersStore.Data.Dictionaries;
using ComputersStore.Data.Entities;
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
        #region Fields

        private readonly UserManager<ApplicationUser> userManager;

        #endregion Fields

        #region Constructors

        public AccountService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        #endregion Constructors

        #region Public methods

        public async Task<IdentityResult> Register(ApplicationUser applicationUser, string password)
        {
            applicationUser.PasswordHash = userManager.PasswordHasher.HashPassword(applicationUser, password);
            var identityResult =  await userManager.CreateAsync(applicationUser);
            if (identityResult.Succeeded)
            {
                await userManager.AddToRoleAsync(applicationUser, ApplicationUserRoleDictionary.Customer);
            }
            return identityResult;
        }

        public async Task<IdentityResult> ConfirmEmail(string applicationUserId, string code)
        {
            var applicationUser = await userManager.FindByIdAsync(applicationUserId);
            return await userManager.ConfirmEmailAsync(applicationUser, code);
        }

        public async Task<bool> IsEmailConfirmed(string applicationUserEmail)
        {
            var applicationUser = await userManager.FindByEmailAsync(applicationUserEmail);
            if(applicationUser != null)
            {
                return await userManager.IsEmailConfirmedAsync(applicationUser);
            }
            return false;
        }

        public async Task<IdentityResult> ResetPassword(string applicationUserEmail, string code, string password)
        {
            var applicationUser = await userManager.FindByEmailAsync(applicationUserEmail);
            if(applicationUser == null)
            {
                return IdentityResult.Failed();
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

        public async Task<string> GenerateResetPasswordToken(string applicationUserId)
        {
            var applicationUser = await userManager.FindByIdAsync(applicationUserId);
            var token = await userManager.GeneratePasswordResetTokenAsync(applicationUser);
            return token;
        }

        public async Task<IdentityResult> UpdateAccountData(ApplicationUser applicationUser)
        {
            return await userManager.UpdateAsync(applicationUser);
        }

        #endregion Public methods
    }
}
