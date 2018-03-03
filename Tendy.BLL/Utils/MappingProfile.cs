using AutoMapper;
using Tendy.BLL.ViewModels;
using Tendy.DAL.Entities;

namespace Tendy.BLL.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //--- Entities-ViewModels
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<ApplicationUserViewModel, ApplicationUser>();

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();

            CreateMap<IdeaCategory, IdeaCategoryViewModel>();
            CreateMap<IdeaCategoryViewModel, IdeaCategory>();

            CreateMap<Idea, IdeaViewModel>();
            CreateMap<IdeaViewModel, Idea>();

			CreateMap<Link, LinkViewModel>();
			CreateMap<LinkViewModel, Link>();

			CreateMap<File, FileViewModel>();
			CreateMap<FileViewModel, File>();

			CreateMap<PeopleGroup, PeopleGroupViewModel>();
            CreateMap<PeopleGroupViewModel, PeopleGroup>();

            CreateMap<Request, RequestViewModel>();
            CreateMap<RequestViewModel, Request>();

            CreateMap<UserProfile, UserProfileViewModel>();
            CreateMap<UserProfileViewModel, UserProfile>();

			CreateMap<AccountSettings, AccountSettingsViewModel>();
			CreateMap<AccountSettingsViewModel, AccountSettings>();

			//--- AuxiliaryViewModels
			CreateMap<RegistrationViewModel, ApplicationUser>()
                    .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
            CreateMap<ApplicationUser, RegistrationViewModel>()
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));
        }
    }
}
