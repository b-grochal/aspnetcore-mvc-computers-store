using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.Account;
using ComputersStore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class AccountBusinessService : IAccountBusinessService
    {
        private readonly IAccountService accountService;
        private readonly IMapper mapper;
        public AccountBusinessService(IAccountService accountService, IMapper mapper)
        {
            this.accountService = accountService;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel, string applicationUserId)
        {
            return await accountService.ChangePassword(applicationUserId, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword); 
        }

        public async Task<IdentityResult> ConfirmEmail(string applicationUserId, string code)
        {
            return await accountService.ConfirmEmail(applicationUserId, code);
        }

        public async Task<bool> IsEmailConfirmed(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            return await accountService.IsEmailConfirmed(forgotPasswordViewModel.Email);
        }

        public async Task<IdentityResult> Register(RegisterViewModel registerViewModel)
        {
            var applicationUser = mapper.Map<ApplicationUser>(registerViewModel);
            return await accountService.Register(applicationUser);
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            return await accountService.ResetPassword(resetPasswordViewModel.Email, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
        }
    }
}
