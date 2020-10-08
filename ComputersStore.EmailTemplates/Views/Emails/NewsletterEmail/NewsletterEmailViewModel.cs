using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailTemplates.Views.Emails.NewsletterEmail
{
    public class NewsletterEmailViewModel
    {
        public NewsletterEmailViewModel(string content)
        {
            this.Content = content;
        }

        public string Content { get; set; }
    }
}
