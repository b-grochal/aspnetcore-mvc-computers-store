using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailTemplates.Views.Emails.ConfirmAccountEmail
{
    public class ConfirmAccountEmailViewModel
    {
        public ConfirmAccountEmailViewModel(string confirmEmailUrl)
        {
            ConfirmEmailUrl = confirmEmailUrl;
        }

        public string ConfirmEmailUrl { get; set; }
    }
}
