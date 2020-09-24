using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Data.Entities;
using ComputersStore.EmailService.Service.Implementation;
using ComputersStore.EmailService.Service.Interface;
using ComputersStore.Models.ViewModels.Account;
using ComputersStore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
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
        private readonly IEmailMessagesService emailMessagesService;
        public AccountBusinessService(IAccountService accountService, IMapper mapper, IEmailMessagesService emailMessagesService)
        {
            this.accountService = accountService;
            this.mapper = mapper;
            this.emailMessagesService = emailMessagesService;
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
            var result = await accountService.Register(applicationUser);
            return result; 
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            return await accountService.ResetPassword(resetPasswordViewModel.Email, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
        }

        public async Task<string> GenerateAccountEmailConfirmationTokenForUser(string applicationUserId)
        {
            var token = await accountService.GenerateEmailConfirmationToken(applicationUserId);
            return token;
        }

        public async Task<string> GenerateResetPasswordTokenForUser(string applicationUserId)
        {
            var token = await accountService.GenerateResetPasswordToken(applicationUserId);
            return token;
        }

        public async Task<AccountDataViewModel> GetApplicationUserAccountData(string applicationUserId)
        {
            var applicationUser = await accountService.GetApplicationUserById(applicationUserId);
            var result = mapper.Map<AccountDataViewModel>(applicationUser);
            return result;
        }

        public async Task<IdentityResult> UpdateAccountData(AccountDataViewModel accountDataViewModel, string applicationUserId)
        {
            var applicationUser = await accountService.GetApplicationUserById(applicationUserId);
            var updatedApplicationUser = mapper.Map(accountDataViewModel, applicationUser);
            return await accountService.UpdateAccountData(updatedApplicationUser);
        }

        
    }
}
