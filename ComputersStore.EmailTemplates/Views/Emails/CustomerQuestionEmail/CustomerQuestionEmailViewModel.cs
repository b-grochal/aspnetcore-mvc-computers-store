using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailTemplates.Views.Emails.CustomerQuestionEmail
{
    public class CustomerQuestionEmailViewModel
    {
        public CustomerQuestionEmailViewModel(string content)
        {
            this.Content = content;
        }

        public string Content { get; set; }
    }
}
