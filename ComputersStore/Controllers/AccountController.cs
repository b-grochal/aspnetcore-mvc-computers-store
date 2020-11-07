using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Data.Entities;
using ComputersStore.EmailHelper.Service.Interface;
using ComputersStore.Models.ViewModels.Account;
using ComputersStore.Models.ViewModels.Emails;
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
        private readonly IAccountBusinessService accountBusinessService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IApplicationUserBusinessService applicationUserBusinessService;
        private readonly IOrderBusinessService orderBusinessService;
        private readonly IEmailService emailMessagesService;
        private readonly int ordersPerPage = 5;

        public AccountController(IAccountBusinessService accountBusinessService, SignInManager<ApplicationUser> signInManager, IApplicationUserBusinessService applicationUserBusinessService, IOrderBusinessService orderBusinessService, IEmailService emailMessagesService)
        {
            this.accountBusinessService = accountBusinessService;
            this.signInManager = signInManager;
            this.applicationUserBusinessService = applicationUserBusinessService;
            this.orderBusinessService = orderBusinessService;
            this.emailMessagesService = emailMessagesService;
        }

        //
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
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

        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
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

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // GET: /Account/ConfirmEmail
        [HttpGet]
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

        //
        // GET: /Account/ForgotPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
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

        //
        // GET: /Account/ForgotPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
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

        //
        // GET: /Account/ResetPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        // GET: /Manage/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var applicationUserId = GetCurrentUserId();
            if (applicationUserId != null)
            {
                var result = await accountBusinessService.ChangePassword(model, applicationUserId);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                AddErrors(result);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        //GET: /Account/UpdateAccountData
        [HttpGet]
        public async Task<IActionResult> UpdateAccountData()
        {
            var accountData = await accountBusinessService.GetApplicationUserAccountData(GetCurrentUserId());
            return View(accountData);
        }

        //
        // POST: /Account/UpdateAccountData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAccountData(AccountDataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var applicationUserId = GetCurrentUserId();
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
            return RedirectToAction(nameof(Index));
        }

        //
        // GET: /Account/UpdateAccountDataConfirmation
        [HttpGet]
        public IActionResult UpdateAccountDataConfirmation()
        {
            return View();
        }

        [HttpGet("Account/Orders")]
        public async Task<IActionResult> ApplicationUserOrders(int pageNumber = 1)
        {
            var orders = await orderBusinessService.GetApplicationUserOrders(GetCurrentUserId(), pageNumber, ordersPerPage, ordersPerPage);
            return View(orders);
        }

        [HttpGet]
        public IActionResult AskQuestion()
        {
            return View();
        }

        //POST: Newsletters/SendNewsletter
        [HttpPost]
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

        [HttpGet]
        public IActionResult AskQuestionConfirmation()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private string GetCurrentUserId()
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
            var customer = await applicationUserBusinessService.GetApplicationUserById(GetCurrentUserId());
            var adminsEmailAddressesCollection = await applicationUserBusinessService.GetApplicationUsersEmailsCollection();
            await emailMessagesService.SendCustomerQuestionEmail(adminsEmailAddressesCollection, $"{customer.FirstName} {customer.SecondName}", emailMessageFormViewModel.Title, emailMessageFormViewModel.Content);
        }
        #endregion
    }
}
