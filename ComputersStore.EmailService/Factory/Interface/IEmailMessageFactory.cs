using ComputersStore.EmailHelper.Messages;
using ComputersStore.Models.ViewModels.Emails;
using ComputersStore.Models.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.EmailHelper.Factory.Interface
{
    public interface IEmailMessageFactory
    {
        Task<Message> GenerateConfirmAccoutEmailMessage(string toEmailAdress, string confirmAccountUrl);
        Task<Message> GenerateResetPasswordEmailMessage(string toEmailAdress, string resetPasswordUrl);
        Task<Message> GenerateCustomerQuestionEmailMessage(IEnumerable<string> adminEmailAdressess, EmailMessageContentViewModel emailMessageContentViewModel);
        Task<Message> GenerateNewOrderAcceptanceConfirmationEmailMessage(string toEmailAddress, OrderDetailsViewModel orderDetailsViewModel);
        Task<Message> GenerateNewsletterEmailMessage(IEnumerable<string> newsletterEmailAdresses, EmailMessageContentViewModel emailMessageContentViewModel);
        Task<Message> GenerateOrderStatusChangedEmailMessage(string toEmailAddress, OrderViewModel orderViewModel);
    }
}
