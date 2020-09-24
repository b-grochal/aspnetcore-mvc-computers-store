using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.Newsletter;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.Mappings
{
    public class NewsletterMappingProfile : Profile
    {
        public NewsletterMappingProfile()
        {
            CreateMap<NewsletterSignUpFormViewModel, Newsletter>();
            CreateMap<Newsletter, NewsletterViewModel>();
        }
    }
}
