using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailTemplates.Views.Emails.ConfirmAccountEmail
{
    public class ConfirmAccountEmailViewModel
    {
        public ConfirmAccountEmailViewModel(string customerFirstName, string confirmEmailUrl)
        {
            this.CustomerFirstName = customerFirstName;
            this.ConfirmEmailUrl = confirmEmailUrl;
        }
        public string CustomerFirstName { get; set; }
        public string ConfirmEmailUrl { get; set; }
    }
}
