using AutoMapper;
using KnowlyApp.Core.Application.DTOs.Account;
using KnowlyApp.Core.Application.ViewModels.Users;
using KnowlyApp.Core.Application.ViewModels.Users;

namespace KnowlyApp.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<AuthenticationRequest, LoginViewModel>()
                   .ForMember(x => x.HasError, opt => opt.Ignore())
              .ForMember(x => x.Error, opt => opt.Ignore())
              .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<RegisterRequest, SaveAdminViewModel>()
             .ForMember(x => x.HasError, opt => opt.Ignore())
             .ForMember(x => x.Error, opt => opt.Ignore())
             .ReverseMap();

            CreateMap<RegisterRequest, EditUserViewModel>()
           .ForMember(x => x.HasError, opt => opt.Ignore())
           .ForMember(x => x.Error, opt => opt.Ignore())
           .ReverseMap();

        }
    }
}
