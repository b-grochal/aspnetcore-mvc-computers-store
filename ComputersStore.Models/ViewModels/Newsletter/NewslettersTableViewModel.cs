using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Newsletter
{
    public class NewslettersTableViewModel
    {
        public IEnumerable<NewsletterViewModel> Newsletters { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
    }
}
