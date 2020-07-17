using ComputersStore.EmailService.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailService.Sender.Interface
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
