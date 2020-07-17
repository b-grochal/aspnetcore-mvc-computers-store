using ComputersStore.EmailService.Factory.Interface;
using ComputersStore.EmailService.Messages;
using ComputersStore.EmailTemplates.Renderer.Interface;
using ComputersStore.EmailTemplates.Views.Emails.ConfirmAccountEmail;
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
    }
}
