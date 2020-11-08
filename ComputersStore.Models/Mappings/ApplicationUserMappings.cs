using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.ApplicationUser.Base;

namespace ComputersStore.Models.Mappings
{
    public class ApplicationUserMappings : Profile
    {
        public ApplicationUserMappings()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
