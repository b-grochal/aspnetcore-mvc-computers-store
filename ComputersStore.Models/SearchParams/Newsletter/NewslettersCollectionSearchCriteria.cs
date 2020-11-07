using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.SearchParams.Newsletter
{
    public class NewslettersCollectionSearchCriteria
    {
        public int? NewsletterId { get; set; }
        public string NewsletterEmail { get; set; }
    }
}
