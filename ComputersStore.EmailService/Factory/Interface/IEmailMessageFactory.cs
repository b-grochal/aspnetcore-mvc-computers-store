using ComputersStore.EmailHelper.Messages;
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
    }
}
