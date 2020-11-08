using ComputersStore.Models.ViewModels.Account.Base;
using Microsoft.AspNetCore.Identity;
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
        Task<AccountDataViewModel> GetApplicationUserAccountData(string applicationUserId);
        Task<IdentityResult> UpdateAccountData(AccountDataViewModel accountDataViewModel, string applicationUserId);

    }
}
