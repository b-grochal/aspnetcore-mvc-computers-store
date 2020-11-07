using ComputersStore.Models.SearchParams;
using ComputersStore.Models.SearchParams.Newsletter;
using ComputersStore.Models.ViewModels.Newsletter.Base;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Newsletter.Complex
{
    public class NewslettersTableViewModel
    {
        public IEnumerable<NewsletterViewModel> Newsletters { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public NewslettersCollectionSearchCriteria newslettersCollectionSearchCritera { get; set; }
    }
}
