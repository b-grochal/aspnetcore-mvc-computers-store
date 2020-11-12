using ComputersStore.EmailHelper.Factory.Interface;
using ComputersStore.EmailHelper.Sender.Interface;
using ComputersStore.EmailHelper.Service.Interface;
using ComputersStore.Models.ViewModels.Emails;
using ComputersStore.Models.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.EmailHelper.Service.Implementation
{
    public class EmailService : IEmailService
    {
        #region Fields

        private readonly IEmailSender emailSender;
        private readonly IEmailMessageFactory emailMessageFactory;

        #endregion Fields

        #region Constructors

        public EmailService(IEmailSender emailSender, IEmailMessageFactory emailMessageFactory)
        {
            this.emailSender = emailSender;
            this.emailMessageFactory = emailMessageFactory;
        }

        #endregion Constructors

        #region Public methods

        public async Task SendConfirmAccountEmail(string toEmailAddress, string customerFirstName, string confirmAccountEmailUrl)
        {
            var confirmEmailAccountMessage = await emailMessageFactory.GenerateConfirmAccoutEmailMessage(toEmailAddress, customerFirstName, confirmAccountEmailUrl);
            emailSender.SendEmail(confirmEmailAccountMessage);
        }

        public async Task SendCustomerQuestionEmail(IEnumerable<string> adminEmailAdressess, string customerFullName, string title, string content)
        {
            var customerQuestionEmailMessage = await emailMessageFactory.GenerateCustomerQuestionEmailMessage(adminEmailAdressess, customerFullName, title, content);
            emailSender.SendEmail(customerQuestionEmailMessage);
        }

        public async Task SendNewOrderAcceptanceConfirmationEmail(string toEmailAddress, string customerFirstName, int orderId)
        {
            var newOrderAcceptanceConfirmationEmailMessage = await emailMessageFactory.GenerateNewOrderConfirmationEmailMessage(toEmailAddress, customerFirstName, orderId);
            emailSender.SendEmail(newOrderAcceptanceConfirmationEmailMessage);
        }

        public async Task SendNewsletterEmail(IEnumerable<string> newsletterEmailAdresses, string title, string content)
        {
            var newsletterEmailMessage = await emailMessageFactory.GenerateNewsletterEmailMessage(newsletterEmailAdresses, title, content);
            emailSender.SendEmail(newsletterEmailMessage);
        }

        public async Task SendOrderStatusChangedEmail(string toEmailAddress, string custmerFirstName, int orderId, string newStatusName)
        {
            var orderStatusChangedEmail = await emailMessageFactory.GenerateOrderStatusChangedEmailMessage(toEmailAddress, custmerFirstName, orderId, newStatusName);
            emailSender.SendEmail(orderStatusChangedEmail);
        }

        public async Task SendResetPasswordEmail(string toEmailAddress, string customerFirstName, string resetPasswordUrl)
        {
            var confirmEmailAccountMessage = await emailMessageFactory.GenerateResetPasswordEmailMessage(toEmailAddress, customerFirstName, resetPasswordUrl);
            emailSender.SendEmail(confirmEmailAccountMessage);
        }

        #endregion Public methods
    }
}
