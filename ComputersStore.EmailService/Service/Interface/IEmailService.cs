using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.EmailHelper.Service.Interface
{
    public interface IEmailService
    {
        Task SendConfirmAccountEmail(string toEmailAddress, string confirmAccountEmailUrl);
        Task SendResetPasswordEmail(string toEmailAddress, string resetPasswordUrl);
    }
}
