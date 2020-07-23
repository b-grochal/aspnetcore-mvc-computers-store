using ComputersStore.EmailService.Factory.Interface;
using ComputersStore.EmailService.Messages;
using ComputersStore.EmailTemplates.Renderer.Interface;
using ComputersStore.EmailTemplates.Views.Emails.ConfirmAccountEmail;
using ComputersStore.EmailTemplates.Views.Emails.ResetPasswordEmail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.EmailService.Factory.Implementation
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

        public async Task<Message> GenerateResetPasswordEmailMessage(string toEmailAdress, string resetPasswordUrl)
        {
            var resetPasswordEmailViewModel = new ResetPasswordEmailViewModel(resetPasswordUrl);
            var emailBody = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/ResetPasswordEmail/ResetPasswordEmail.cshtml", resetPasswordEmailViewModel);
            var resetPasswordEmailMessage = new Message(new string[] { toEmailAdress }, "Reset password.", emailBody);
            return resetPasswordEmailMessage;
        }
    }
}
