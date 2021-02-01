using ComputersStore.EmailHelper.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailHelper.Sender.Interface
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
