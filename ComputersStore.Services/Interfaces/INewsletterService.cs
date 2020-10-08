using ComputersStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface INewsletterService
    {
        Task CreateNewsletter(Newsletter newsletter);
        Task DeleteNewsletter(int newsletterId);
        Task<IEnumerable<Newsletter>> GetNewslettersCollection(int? newsletterId, string newsletterEmail, int pageNumber, int pageSize);
        Task<Newsletter> GetNewsletter(int newsletterId);
        int GetNewslettersCollectionCount();
        Task<IEnumerable<string>> GetNewslettersEmailsCollection();
    }
}
