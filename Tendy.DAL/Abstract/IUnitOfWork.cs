using Tendy.DAL.Abstract;
using Tendy.DAL.Entities;

namespace Tendy.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<ApplicationUser> ApplicationUsersRepository { get; }
        IRepository<UserProfile> UserProfilesRepository { get; }
        IRepository<Idea> IdeasRepository { get; }
        IRepository<IdeaImage> IdeaImagesRepository { get; }
        IRepository<AttachmentGroup> AttachmentsGroupsRepository { get; }
        IRepository<Attachment> AttachmentsRepository { get; }
        IRepository<Publication> PublicationsRepository { get; }
        IRepository<PublicationImage> PublicationImagesRepository { get; }
        IRepository<Image> ImagesRepository { get; }
        IRepository<Category> CategoriesRepository { get; }
        IRepository<Request> RequestsRepository { get; }
        IRepository<PeopleGroup> PeopleGroupsRepository { get; }

        void SaveChanges();
    }
}
