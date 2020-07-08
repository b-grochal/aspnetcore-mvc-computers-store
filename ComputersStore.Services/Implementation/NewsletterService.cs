﻿using ComputersStore.Core.Data;
using ComputersStore.Data;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Implementation
{
    public class NewsletterService : INewsletterService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public NewsletterService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task CreateNewsletter(Newsletter newsletter)
        {
            applicationDbContext.Newsletters.Add(newsletter);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteNewsletter(int newsletterId)
        {
            var newsletter = await applicationDbContext.Newsletters.FindAsync(newsletterId);
            applicationDbContext.Remove(newsletter);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Newsletter> GetNewsletter(int newsletterId)
        {
            return await applicationDbContext.Newsletters.FindAsync(newsletterId);
        }

        public async Task<IEnumerable<Newsletter>> GetNewslettersCollection()
        {
            var newsletters = await applicationDbContext.Newsletters.ToListAsync();
            return newsletters;
        }
    }
}