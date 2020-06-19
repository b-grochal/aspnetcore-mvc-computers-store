using ComputersStore.Core.Data;
using ComputersStore.Data;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Services.Implementation
{
    public class NewsletterService : INewsletterService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public NewsletterService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void CreateNewsletter(Newsletter newsletter)
        {
            applicationDbContext.Newsletters.Add(newsletter);
            applicationDbContext.SaveChanges();
        }
    }
}
