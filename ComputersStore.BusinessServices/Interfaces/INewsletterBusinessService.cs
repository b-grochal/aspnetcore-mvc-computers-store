using ComputersStore.Models.ViewModels.Newsletter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface INewsletterBusinessService
    {
        Task CreateNewsletter(NewsletterSignUpFormViewModel newsletterSignUpFormViewModel);
        Task DeleteNewsletter(int newsletterId);
        Task<NewslettersTableViewModel> GetNewslletersCollection(int pageNumber, int pageSize);
        Task<NewsletterViewModel> GetNewsletter(int newsletterId);
    }
}
