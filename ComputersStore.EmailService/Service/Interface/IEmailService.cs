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
        Task SendConfirmAccountEmail(string toEmailAddress, string customerFirstName, string confirmAccountEmailUrl);
        Task SendResetPasswordEmail(string toEmailAddress, string customerFirstName, string resetPasswordUrl);
        Task SendOrderStatusChangedEmail(string toEmailAddress, string custmerFirstName, int orderId, string newStatusName);
        Task SendNewOrderAcceptanceConfirmationEmail(string toEmailAddress, string customerFirstName, int orderId);
        Task SendNewsletterEmail(IEnumerable<string> newsletterEmailAdresses, string title, string content);
        Task SendCustomerQuestionEmail(IEnumerable<string> adminEmailAdressess, string customerFullName, string title, string content);
    }
}
