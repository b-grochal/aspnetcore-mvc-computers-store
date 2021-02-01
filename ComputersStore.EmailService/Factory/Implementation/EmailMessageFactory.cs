using ComputersStore.EmailHelper.Factory.Interface;
using ComputersStore.EmailHelper.Messages;
using ComputersStore.EmailTemplates.Renderer.Interface;
using ComputersStore.EmailTemplates.Views.Emails.ConfirmAccountEmail;
using ComputersStore.EmailTemplates.Views.Emails.CustomerQuestionEmail;
using ComputersStore.EmailTemplates.Views.Emails.NewOrderConfirmationEmail;
using ComputersStore.EmailTemplates.Views.Emails.NewsletterEmail;
using ComputersStore.EmailTemplates.Views.Emails.OrderStatusChangedEmail;
using ComputersStore.EmailTemplates.Views.Emails.ResetPasswordEmail;
using ComputersStore.Models.ViewModels.Emails;
using ComputersStore.Models.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.EmailHelper.Factory.Implementation
{
    public class EmailMessageFactory : IEmailMessageFactory
    {
        #region Fields

        private readonly IRazorViewToStringRenderer razorViewToStringRenderer;

        #endregion Fields

        #region Constructors

        public EmailMessageFactory(IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            this.razorViewToStringRenderer = razorViewToStringRenderer;
        }

        #endregion Constructors

        #region Public methods

        public async Task<Message> GenerateConfirmAccoutEmailMessage(string toEmailAdress, string customerFirstName, string confirmAccountUrl)
        {
            var confirmAccountEmailViewModel = new ConfirmAccountEmailViewModel(customerFirstName, confirmAccountUrl);
            var emailBody = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/ConfirmAccountEmail/ConfirmAccountEmail.cshtml", confirmAccountEmailViewModel);
            var confirmAccountEmailMessage = new Message(new string[] { toEmailAdress }, "Confirm your account email address.", emailBody);              
            return confirmAccountEmailMessage;
        }

        public async Task<Message> GenerateCustomerQuestionEmailMessage(IEnumerable<string> adminEmailAdressess, string customerFulltName, string title, string content)
        {
            var customerQuestionEmailViewModel = new CustomerQuestionEmailViewModel(customerFulltName, content);
            var emailBody = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/CustomerQuestionEmail/CustomerQuestionEmail.cshtml", customerQuestionEmailViewModel);
            var customerQuestionEmailMessage = new Message(adminEmailAdressess, title, emailBody);
            return customerQuestionEmailMessage;
        }

        public async Task<Message> GenerateNewOrderConfirmationEmailMessage(string toEmailAddress, string cutomerFirstName, int orderId)
        {
            var newOrderConfirmationEmailViewModel = new NewOrderConfirmationEmailViewModel(cutomerFirstName, orderId);
            var emailBody = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/NewOrderConfirmationEmail/NewOrderConfirmationEmail.cshtml", newOrderConfirmationEmailViewModel);
            var newOrderConfirmationEmailMesssage = new Message(new string[] { toEmailAddress }, "New order confirmation", emailBody);
            return newOrderConfirmationEmailMesssage;
        }

        public async Task<Message> GenerateNewsletterEmailMessage(IEnumerable<string> newsletterEmailAdresses, string title, string content)
        {
            var newsletterEmailViewModel = new NewsletterEmailViewModel(content);
            var emailBody = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/NewsletterEmail/NewsletterEmail.cshtml", newsletterEmailViewModel);
            var newsletterEmailMessage = new Message(newsletterEmailAdresses, title, emailBody);
            return newsletterEmailMessage;
        }

        public async Task<Message> GenerateOrderStatusChangedEmailMessage(string toEmailAddress, string cutomerFirstName, int orderId, string newStatusName)
        {
            var orderStatusChangedEmailViewModel = new OrderStatusChangedEmailViewModel(cutomerFirstName, orderId, newStatusName);
            var emailBody = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/OrderStatusChangedEmail/OrderStatusChangedEmail.cshtml", orderStatusChangedEmailViewModel);
            var orderStatusChangedEmailMessage = new Message(new string[] { toEmailAddress }, "Order status change", emailBody);
            return orderStatusChangedEmailMessage;
        }

        public async Task<Message> GenerateResetPasswordEmailMessage(string toEmailAdress, string customerFirstName, string resetPasswordUrl)
        {
            var resetPasswordEmailViewModel = new ResetPasswordEmailViewModel(customerFirstName, resetPasswordUrl);
            var emailBody = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/ResetPasswordEmail/ResetPasswordEmail.cshtml", resetPasswordEmailViewModel);
            var resetPasswordEmailMessage = new Message(new string[] { toEmailAdress }, "Reset password.", emailBody);
            return resetPasswordEmailMessage;
        }

        #endregion Public methods
    }
}
