using ComputersStore.Core.Data;
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

        //public Task<string> GenerateEmailConfirmationToken(string applicationUserEmail)
        //{
        //    var applicationUser = userManager.FindByEmailAsync(applicationUserEmail);
        //    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
        //}
    }
}
