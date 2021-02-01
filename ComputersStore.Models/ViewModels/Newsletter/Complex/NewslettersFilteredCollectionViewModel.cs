using ComputersStore.Models.ViewModels.Newsletter.Base;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Newsletter.Complex
{
    public class NewslettersFilteredCollectionViewModel
    {
        public IEnumerable<NewsletterViewModel> Newsletters { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public int? NewsletterId { get; set; }
        public string NewsletterEmail { get; set; }
}
}
