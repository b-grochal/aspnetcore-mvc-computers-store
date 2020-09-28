using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.Mappings
{
    public class ApplicationUserMappings : Profile
    {
        public ApplicationUserMappings()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.Id));
                //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                //.ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
