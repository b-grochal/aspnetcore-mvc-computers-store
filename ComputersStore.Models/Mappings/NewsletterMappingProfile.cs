using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.Newsletter.Base;

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
