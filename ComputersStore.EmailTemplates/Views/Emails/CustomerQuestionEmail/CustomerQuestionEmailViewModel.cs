using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailTemplates.Views.Emails.CustomerQuestionEmail
{
    public class CustomerQuestionEmailViewModel
    {
        public CustomerQuestionEmailViewModel(string customerFullName, string content)
        {
            this.CustomerFullName = customerFullName;
            this.Content = content;
        }
        public string CustomerFullName { get; set; }
        public string Content { get; set; }
    }
}
