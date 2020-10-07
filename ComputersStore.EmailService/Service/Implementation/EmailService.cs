using ComputersStore.EmailHelper.Factory.Interface;
using ComputersStore.EmailHelper.Sender.Interface;
using ComputersStore.EmailHelper.Service.Interface;
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

        public async Task SendResetPasswordEmail(string toEmailAddress, string resetPasswordUrl)
        {
            var confirmEmailAccountMessage = await emailMessageFactory.GenerateResetPasswordEmailMessage(toEmailAddress, resetPasswordUrl);
            emailSender.SendEmail(confirmEmailAccountMessage);
        }
    }
}
