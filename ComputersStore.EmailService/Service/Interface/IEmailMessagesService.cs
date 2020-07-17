using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.EmailService.Service.Interface
{
    public interface IEmailMessagesService
    {
        Task SendConfirmAccountEmail(string toEmailAddress, string confirmAccountEmailUrl);
    }
}
