using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Data.Dictionaries;
using ComputersStore.Data.Entities;
using ComputersStore.EmailHelper.Service.Interface;
using ComputersStore.Models.ViewModels.Account;
using ComputersStore.Models.ViewModels.Account.Base;
using ComputersStore.Models.ViewModels.Emails;
using ComputersStore.Models.ViewModels.Emails.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace ComputersStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Fields

        private readonly IAccountBusinessService accountBusinessService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IApplicationUserBusinessService applicationUserBusinessService;
        private readonly IOrderBusinessService orderBusinessService;
        private readonly IEmailService emailMessagesService;

        #endregion Fields

        #region Constructors

        public AccountController(IAccountBusinessService accountBusinessService, SignInManager<ApplicationUser> signInManager, IApplicationUserBusinessService applicationUserBusinessService, IOrderBusinessService orderBusinessService, IEmailService emailMessagesService)
        {
            this.accountBusinessService = accountBusinessService;
            this.signInManager = signInManager;
            this.applicationUserBusinessService = applicationUserBusinessService;
            this.orderBusinessService = orderBusinessService;
            this.emailMessagesService = emailMessagesService;
        }

        #endregion Constructors

        #region Actions

        // GET: Account/Login
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await accountBusinessService.Register(model);
                if (result.Succeeded)
                {
                    await SendAccountConfirmationEmail(model.Email);
                    return RedirectToAction(nameof(Login));
                }
                AddErrors(result);
            }
            return View(model);
        }

        // GET: Account/RegisterConfirmation
        [AllowAnonymous]
        public IActionResult RegisterConfirmation()
        {
            return View();
        }

        // POST: Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // GET: Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string applicationUserId, string code)
        {
            if (applicationUserId == null || code == null)
            {
                return View("Error");
            }
            var result = await accountBusinessService.ConfirmEmail(applicationUserId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        // GET: Account/ForgotPassword
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST: Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isEmailConfirmed = await accountBusinessService.IsEmailConfirmed(model);
                if (!isEmailConfirmed)
                {
                    return View("ForgotPasswordConfirmation");
                }
                await SendResetPasswordEmail(model.Email);
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        // GET: Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // GET: Account/ResetPassword
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }

        // POST: Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await accountBusinessService.ResetPassword(model);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(AccountController.ResetPasswordConfirmation), "Account");
            }
            AddErrors(result);
            return View();
        }

        // GET: Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        // GET: Account/ChangePassword
        [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // POST: Account/ChangePassword
        [HttpPost]
        [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var applicationUserId = GetCurrentApplicationUserId();
            if (applicationUserId != null)
            {
                var result = await accountBusinessService.ChangePassword(model, applicationUserId);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ChangePasswordConfirmation));
                }
                AddErrors(result);
                return View(model);
            }
            return RedirectToAction(nameof(ChangePassword));
        }

        // GET: Account/ChangePassword
        [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
        public IActionResult ChangePasswordConfirmation()
        {
            return View();
        }

        // GET: Account/UpdateAccountData
        [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
        public async Task<IActionResult> UpdateAccountData()
        {
            var accountData = await accountBusinessService.GetApplicationUserAccountData(GetCurrentApplicationUserId());
            return View(accountData);
        }

        // POST: Account/UpdateAccountData
        [HttpPost]
        [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAccountData(AccountDataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var applicationUserId = GetCurrentApplicationUserId();
            if (applicationUserId != null)
            {
                var result = await accountBusinessService.UpdateAccountData(model, applicationUserId);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(UpdateAccountDataConfirmation));
                }
                AddErrors(result);
                return View(model);
            }
            return RedirectToAction(nameof(UpdateAccountDataConfirmation));
        }

        // GET: Account/UpdateAccountDataConfirmation
        [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
        public IActionResult UpdateAccountDataConfirmation()
        {
            return View();
        }

        // GET: Account/Orders
        [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
        public async Task<IActionResult> ApplicationUserOrders()
        {
            var orders = await orderBusinessService.GetOrdersCollection(GetCurrentApplicationUserId());
            return View(orders);
        }

        // GET: Account/AskQuestion
        [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
        public IActionResult AskQuestion()
        {
            return View();
        }

        // POST: Account/AskQuestion
        [HttpPost]
        [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AskQuestion(EmailMessageFormViewModel emailMessageFormViewModel)
        {
            if (ModelState.IsValid)
            {
                await SendCustomerQuestionEmail(emailMessageFormViewModel);
                return RedirectToAction(nameof(AskQuestionConfirmation));
            }
            return View(emailMessageFormViewModel);
        }

        // GET: Account/AskQuestionConfirmation
        [Authorize(Roles = ApplicationUserRoleDictionary.Customer)]
        public IActionResult AskQuestionConfirmation()
        {
            return View();
        }

        // GET: Account/AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion Actions

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private string GetCurrentApplicationUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task SendAccountConfirmationEmail(string applicationUserEmail)
        {
            var applicationUser = await applicationUserBusinessService.GetApplicationUserByEmail(applicationUserEmail);
            var emailConfirmationToken = await accountBusinessService.GenerateAccountEmailConfirmationTokenForUser(applicationUser.ApplicationUserId);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { applicationUserId = applicationUser.ApplicationUserId, code = emailConfirmationToken }, protocol: HttpContext.Request.Scheme);
            await emailMessagesService.SendConfirmAccountEmail(applicationUser.Email, applicationUser.FirstName, callbackUrl);
        } 

        private async Task SendResetPasswordEmail(string applicationUserEmail)
        {
            var applicationUser = await applicationUserBusinessService.GetApplicationUserByEmail(applicationUserEmail);
            var resetPasswordToken = await accountBusinessService.GenerateResetPasswordTokenForUser(applicationUser.ApplicationUserId);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { applicationUserId = applicationUser.ApplicationUserId, code = resetPasswordToken }, protocol: HttpContext.Request.Scheme);
            await emailMessagesService.SendResetPasswordEmail(applicationUser.Email, applicationUser.FirstName, callbackUrl);
        }

        private async Task SendCustomerQuestionEmail(EmailMessageFormViewModel emailMessageFormViewModel)
        {
            var customer = await applicationUserBusinessService.GetApplicationUserById(GetCurrentApplicationUserId());
            var adminsEmailAddressesCollection = await applicationUserBusinessService.GetApplicationUsersEmailsCollection(ApplicationUserRoleDictionary.Admin);
            await emailMessagesService.SendCustomerQuestionEmail(adminsEmailAddressesCollection, $"{customer.FirstName} {customer.LastName} ({customer.Email})", emailMessageFormViewModel.Title, emailMessageFormViewModel.Content);
        }

        #endregion Helpers
    }
}
