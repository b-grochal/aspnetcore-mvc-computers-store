using AutoMapper;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.Basic;
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
        }
    }
}
