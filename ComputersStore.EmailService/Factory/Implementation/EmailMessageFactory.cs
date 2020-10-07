using ComputersStore.EmailHelper.Factory.Interface;
using ComputersStore.EmailHelper.Messages;
using ComputersStore.EmailTemplates.Renderer.Interface;
using ComputersStore.EmailTemplates.Views.Emails.ConfirmAccountEmail;
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
        private readonly IRazorViewToStringRenderer razorViewToStringRenderer;
        public EmailMessageFactory(IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            this.razorViewToStringRenderer = razorViewToStringRenderer;
        }

        public async Task<Message> GenerateConfirmAccoutEmailMessage(string toEmailAdress, string confirmAccountUrl)
        {
            var confirmAccountEmailViewModel = new ConfirmAccountEmailViewModel(confirmAccountUrl);
            var emailBody = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/ConfirmAccountEmail/ConfirmAccountEmail.cshtml", confirmAccountEmailViewModel);
            var confirmAccountEmailMessage = new Message(new string[] { toEmailAdress }, "Confirm your account email address.", emailBody);              
            return confirmAccountEmailMessage;
        }

        public Task<Message> GenerateCustomerQuestionEmailMessage(IEnumerable<string> adminEmailAdressess, EmailMessageContentViewModel emailMessageContentViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GenerateNewOrderAcceptanceConfirmationEmailMessage(string toEmailAddress, OrderDetailsViewModel orderDetailsViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GenerateNewsletterEmailMessage(IEnumerable<string> newsletterEmailAdresses, EmailMessageContentViewModel emailMessageContentViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GenerateOrderStatusChangedEmailMessage(string toEmailAddress, OrderViewModel orderViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<Message> GenerateResetPasswordEmailMessage(string toEmailAdress, string resetPasswordUrl)
        {
            var resetPasswordEmailViewModel = new ResetPasswordEmailViewModel(resetPasswordUrl);
            var emailBody = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/ResetPasswordEmail/ResetPasswordEmail.cshtml", resetPasswordEmailViewModel);
            var resetPasswordEmailMessage = new Message(new string[] { toEmailAdress }, "Reset password.", emailBody);
            return resetPasswordEmailMessage;
        }
    }
}
