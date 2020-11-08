using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Data.Entities;
using ComputersStore.Models.SearchParams.Newsletter;
using ComputersStore.Models.ViewModels.Newsletter.Base;
using ComputersStore.Models.ViewModels.Newsletter.Complex;
using ComputersStore.Models.ViewModels.Other;
using ComputersStore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.BusinessServices.Implementation
{
    public class NewsletterBusinessService : INewsletterBusinessService
    {
        private readonly INewsletterService newsletterService;
        private readonly IMapper mapper;

        public NewsletterBusinessService(INewsletterService newsletterService, IMapper mapper)
        {
            this.newsletterService = newsletterService;
            this.mapper = mapper;
        }

        public async Task CreateNewsletter(NewsletterSignUpFormViewModel newsletterSignUpFormViewModel)
        {
            var newsletter = mapper.Map<Newsletter>(newsletterSignUpFormViewModel);
            await newsletterService.CreateNewsletter(newsletter);
        }

        public async Task DeleteNewsletter(int newsletterId)
        {
            await newsletterService.DeleteNewsletter(newsletterId);
        }

        public async Task<IEnumerable<string>> GetNewlettersEmailsCollection()
        {
            return await newsletterService.GetNewslettersEmailsCollection();
        }

        public async Task<NewsletterViewModel> GetNewsletter(int newsletterId)
        {
            var newsletter = await newsletterService.GetNewsletter(newsletterId);
            var result = mapper.Map<NewsletterViewModel>(newsletter);
            return result;
        }

        public async Task<NewslettersTableViewModel> GetNewslletersCollection(int? newsletterId, string newsletterEmail, int pageNumber, int pageSize)
        {
            var newsletters = await newsletterService.GetNewslettersCollection(newsletterId, newsletterEmail, pageNumber, pageSize);
            var result = mapper.Map<IEnumerable<NewsletterViewModel>>(newsletters);
            return new NewslettersTableViewModel
            {
                Newsletters = result,
                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = pageSize,
                    TotalItems = newsletterService.GetNewslettersCollectionCount()
                },
                newslettersCollectionSearchCritera = new NewslettersCollectionSearchCriteria
                {
                    NewsletterId = newsletterId,
                    NewsletterEmail = newsletterEmail
                }
            };
        }

    }
}
