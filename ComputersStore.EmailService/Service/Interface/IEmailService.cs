using ComputersStore.Models.ViewModels.Emails;
using ComputersStore.Models.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.EmailHelper.Service.Interface
{
    public interface IEmailService
    {
        Task SendConfirmAccountEmail(string toEmailAddress, string confirmAccountEmailUrl);
        Task SendResetPasswordEmail(string toEmailAddress, string resetPasswordUrl);
        Task SendOrderStatusChangedEmail(string toEmailAddress, OrderViewModel orderViewModel);
        Task SendNewOrderAcceptanceConfirmationEmail(string toEmailAddress, OrderDetailsViewModel orderDetailsViewModel);
        Task SendNewsletterEmail(IEnumerable<string> newsletterEmailAdresses, EmailMessageFormViewModel emailMessageContentViewModel);
        Task SendCustomerQuestionEmail(IEnumerable<string> adminEmailAdressess, EmailMessageFormViewModel emailMessageContentViewModel);
    }
}
