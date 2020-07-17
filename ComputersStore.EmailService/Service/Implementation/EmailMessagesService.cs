using ComputersStore.EmailService.Factory.Interface;
using ComputersStore.EmailService.Sender.Interface;
using ComputersStore.EmailService.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.EmailService.Service.Implementation
{
    public class EmailMessagesService : IEmailMessagesService
    {
        private readonly IEmailSender emailSender;
        private readonly IEmailMessageFactory emailMessageFactory;
        public EmailMessagesService(IEmailSender emailSender, IEmailMessageFactory emailMessageFactory)
        {
            this.emailSender = emailSender;
            this.emailMessageFactory = emailMessageFactory;
        }

        public async Task SendConfirmAccountEmail(string toEmailAddress, string confirmAccountEmailUrl)
        {
            var confirmEmailAccountMessage = await emailMessageFactory.GenerateConfirmAccoutEmailMessage(toEmailAddress, confirmAccountEmailUrl);
            emailSender.SendEmail(confirmEmailAccountMessage);
        }
    }
}
