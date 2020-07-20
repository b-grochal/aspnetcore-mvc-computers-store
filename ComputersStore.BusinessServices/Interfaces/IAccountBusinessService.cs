using ComputersStore.Models.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IAccountBusinessService
    {
        Task<IdentityResult> Register(RegisterViewModel registerViewModel);
        Task<IdentityResult> ConfirmEmail(string applicationUserId, string code);
        Task<bool> IsEmailConfirmed(ForgotPasswordViewModel forgotPasswordViewModel);
        Task<IdentityResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel);
        Task<IdentityResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel, string applicationUserId);
        Task<string> GenerateAccountEmailConfirmationTokenForUser(string applicationUserId);
        Task<string> GenerateResetPasswordTokenForUser(string applicationUserId);

    }
}
