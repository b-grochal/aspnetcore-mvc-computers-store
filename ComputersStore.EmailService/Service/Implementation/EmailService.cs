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
        private readonly IEmailSender emailSender;
        private readonly IEmailMessageFactory emailMessageFactory;
        public EmailService(IEmailSender emailSender, IEmailMessageFactory emailMessageFactory)
        {
            this.emailSender = emailSender;
            this.emailMessageFactory = emailMessageFactory;
        }

        public async Task SendConfirmAccountEmail(string toEmailAddress, string confirmAccountEmailUrl)
        {
            var confirmEmailAccountMessage = await emailMessageFactory.GenerateConfirmAccoutEmailMessage(toEmailAddress, confirmAccountEmailUrl);
            emailSender.SendEmail(confirmEmailAccountMessage);
        }

        public async Task SendCustomerQuestionEmail(IEnumerable<string> adminEmailAdressess, EmailMessageContentViewModel emailMessageContentViewModel)
        {
            var customerQuestionEmailMessage = await emailMessageFactory.GenerateCustomerQuestionEmailMessage(adminEmailAdressess, emailMessageContentViewModel);
            emailSender.SendEmail(customerQuestionEmailMessage);
        }

        public async Task SendNewOrderAcceptanceConfirmationEmail(string toEmailAddress, OrderDetailsViewModel orderDetailsViewModel)
        {
            var newOrderAcceptanceConfirmationEmailMessage = await emailMessageFactory.GenerateNewOrderAcceptanceConfirmationEmailMessage(toEmailAddress, orderDetailsViewModel);
            emailSender.SendEmail(newOrderAcceptanceConfirmationEmailMessage);
        }

        public async Task SendNewsletterEmail(IEnumerable<string> newsletterEmailAdresses, EmailMessageContentViewModel emailMessageContentViewModel)
        {
            var newsletterEmailMessage = await emailMessageFactory.GenerateNewsletterEmailMessage(newsletterEmailAdresses, emailMessageContentViewModel);
            emailSender.SendEmail(newsletterEmailMessage);
        }

        public async Task SendOrderStatusChangedEmail(string toEmailAddress, OrderViewModel orderViewModel)
        {
            var orderStatusChangedEmail = await emailMessageFactory.GenerateOrderStatusChangedEmailMessage(toEmailAddress, orderViewModel);
            emailSender.SendEmail(orderStatusChangedEmail);
        }

        public async Task SendResetPasswordEmail(string toEmailAddress, string resetPasswordUrl)
        {
            var confirmEmailAccountMessage = await emailMessageFactory.GenerateResetPasswordEmailMessage(toEmailAddress, resetPasswordUrl);
            emailSender.SendEmail(confirmEmailAccountMessage);
        }
    }
}
