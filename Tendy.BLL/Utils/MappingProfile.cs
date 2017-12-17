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

            CreateMap<AttachmentGroup, AttachmentGroupViewModel>();
            CreateMap<AttachmentGroupViewModel, AttachmentGroup>();

            CreateMap<Attachment, AttachmentViewModel>();
            CreateMap<AttachmentViewModel, Attachment>();

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();

            CreateMap<IdeaCategory, IdeaCategoryViewModel>();
            CreateMap<IdeaCategoryViewModel, IdeaCategory>();

            CreateMap<IdeaImage, IdeaImageViewModel>();
            CreateMap<IdeaImageViewModel, IdeaImage>();

            CreateMap<Idea, IdeaViewModel>();
            CreateMap<IdeaViewModel, Idea>();

            CreateMap<Image, ImageViewModel>();
            CreateMap<ImageViewModel, Image>();

            CreateMap<PeopleGroup, PeopleGroupViewModel>();
            CreateMap<PeopleGroupViewModel, PeopleGroup>();

            CreateMap<PublicationImage, PublicationImageViewModel>();
            CreateMap<PublicationImageViewModel, PublicationImage>();

            CreateMap<Publication, PublicationViewModel>();
            CreateMap<PublicationViewModel, Publication>();

            CreateMap<Request, RequestViewModel>();
            CreateMap<RequestViewModel, Request>();

            CreateMap<UserProfile, UserProfileViewModel>();
            CreateMap<UserProfileViewModel, UserProfile>();

            //--- AuxiliaryViewModels
            CreateMap<RegistrationViewModel, ApplicationUser>();
            CreateMap<ApplicationUser, RegistrationViewModel>();
        }
    }
}
