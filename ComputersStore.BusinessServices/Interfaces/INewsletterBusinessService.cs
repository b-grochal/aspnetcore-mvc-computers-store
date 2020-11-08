using ComputersStore.Models.ViewModels.Newsletter.Base;
using ComputersStore.Models.ViewModels.Newsletter.Complex;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface INewsletterBusinessService
    {
        Task CreateNewsletter(NewsletterSignUpFormViewModel newsletterSignUpFormViewModel);
        Task DeleteNewsletter(int newsletterId);
        Task<NewslettersTableViewModel> GetNewslletersCollection(int? newsletterId, string newsletterEmail, int pageNumber, int pageSize);
        Task<NewsletterViewModel> GetNewsletter(int newsletterId);
        Task<IEnumerable<string>> GetNewlettersEmailsCollection();
    }
}
