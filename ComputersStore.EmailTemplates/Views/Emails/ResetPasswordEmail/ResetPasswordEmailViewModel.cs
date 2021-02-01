using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailTemplates.Views.Emails.ResetPasswordEmail
{
    public class ResetPasswordEmailViewModel
    {
        public ResetPasswordEmailViewModel(string customerFirstName, string resetPasswordUrl)
        {
            this.CustomerFirstName = customerFirstName;
            this.ResetPasswordUrl = resetPasswordUrl;
        }
        public string CustomerFirstName { get; set; }
        public string ResetPasswordUrl { get; set; }
    }
}
