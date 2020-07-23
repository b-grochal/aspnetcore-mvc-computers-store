using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.EmailTemplates.ViewModels
{
    public class EmailButtonViewModel
    {
        public EmailButtonViewModel(string text, string url)
        {
            Text = text;
            Url = url;
        }

        public string Text { get; set; }
        public string Url { get; set; }
    }
}
