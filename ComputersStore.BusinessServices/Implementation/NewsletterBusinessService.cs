using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.Basic;
using ComputersStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void CreateNewsletter(NewsletterSignUpFormViewModel newsletterSignUpFormViewModel)
        {
            var newsletter = mapper.Map<Newsletter>(newsletterSignUpFormViewModel);
            newsletterService.CreateNewsletter(newsletter);
        }
    }
}
