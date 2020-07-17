using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailTemplates.Views.Emails.ResetPasswordEmail
{
    public class ResetPasswordEmailViewModel
    {
        public ResetPasswordEmailViewModel(string resetPasswordUrl)
        {
            ResetPasswordUrl = resetPasswordUrl;
        }

        public string ResetPasswordUrl { get; set; }
    }
}
