using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.Account.Base;

namespace ComputersStore.Models.Mappings
{
    public class AccountMappings : Profile
    {
        public AccountMappings()
        {
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<ApplicationUser, AccountDataViewModel>();

            CreateMap<AccountDataViewModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}
