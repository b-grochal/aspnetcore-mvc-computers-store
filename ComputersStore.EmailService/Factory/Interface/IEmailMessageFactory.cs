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
        Task<Message> GenerateConfirmAccoutEmailMessage(string toEmailAdress, string customerFirstName, string confirmAccountUrl);
        Task<Message> GenerateResetPasswordEmailMessage(string toEmailAdress, string customerFirstName, string resetPasswordUrl);
        Task<Message> GenerateCustomerQuestionEmailMessage(IEnumerable<string> adminEmailAdressess, string customerFullName, string title, string content);
        Task<Message> GenerateNewOrderConfirmationEmailMessage(string toEmailAddress, string cutomerFirstName, int orderId);
        Task<Message> GenerateNewsletterEmailMessage(IEnumerable<string> newsletterEmailAdresses, string title, string content);
        Task<Message> GenerateOrderStatusChangedEmailMessage(string toEmailAddress, string cutomerFirstName, int orderId, string newStatusName);
    }
}
