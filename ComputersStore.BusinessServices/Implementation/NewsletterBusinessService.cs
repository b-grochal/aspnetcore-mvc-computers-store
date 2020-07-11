using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.Newsletter;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<NewsletterViewModel> GetNewsletter(int newsletterId)
        {
            var newsletter = await newsletterService.GetNewsletter(newsletterId);
            var result = mapper.Map<NewsletterViewModel>(newsletter);
            return result;
        }

        public async Task<IEnumerable<NewsletterViewModel>> GetNewslletersCollection()
        {
            var newsletters = await newsletterService.GetNewslettersCollection();
            var result = mapper.Map<IEnumerable<NewsletterViewModel>>(newsletters);
            return result;
        }

    }
}
