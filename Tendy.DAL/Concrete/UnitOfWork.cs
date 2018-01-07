using Tendy.DAL.Abstract;
using Tendy.DAL.EF;
using Tendy.DAL.Entities;
using Tendy.Abstract;

namespace Tendy.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        private readonly IRepository<ApplicationUser> _applicationUsersRepository;
        private readonly IRepository<UserProfile> _userProfilesRepository;
        private readonly IRepository<Idea> _ideasRepository;
        private readonly IRepository<IdeaImage> _ideaImagesRepository;
        private readonly IRepository<AttachmentGroup> _attachmentsGroupsRepository;
        private readonly IRepository<Attachment> _attachmentsRepository;
        private readonly IRepository<Publication> _publicationsRepository;
        private readonly IRepository<PublicationImage> _publicationImagesRepository;
        private readonly IRepository<Image> _imagesRepository;
        private readonly IRepository<Category> _categoriesRepository;
        private readonly IRepository<Request> _requestsRepository;
        private readonly IRepository<PeopleGroup> _peopleGroupsRepository;
		private readonly IRepository<IdeaCategory> _ideasCategoriesRepository;

		public UnitOfWork(ApplicationDbContext context,
            IRepository<ApplicationUser> applicationUsersRepository,
            IRepository<UserProfile> userProfilesRepository,
            IRepository<Idea> ideasRepository,
            IRepository<IdeaImage> ideaImagesRepository,
            IRepository<AttachmentGroup> attachmentsGroupsRepository,
            IRepository<Attachment> attachmentsRepository,
            IRepository<Publication> publicationsRepository,
            IRepository<PublicationImage> publicationImagesRepository,
            IRepository<Image> imagesRepository,
            IRepository<Category> categoriesRepository,
            IRepository<Request> requestsRepository,
            IRepository<PeopleGroup> peopleGroupsRepository,
            IRepository<IdeaCategory> ideasCategoriesRepository)
        {
			Context = context;
            _applicationUsersRepository = applicationUsersRepository;
            _userProfilesRepository = userProfilesRepository;
            _ideasRepository = ideasRepository;
            _ideaImagesRepository = ideaImagesRepository;
            _attachmentsGroupsRepository = attachmentsGroupsRepository;
            _attachmentsRepository = attachmentsRepository;
            _publicationsRepository = publicationsRepository;
            _publicationImagesRepository = publicationImagesRepository;
            _imagesRepository = imagesRepository;
            _categoriesRepository = categoriesRepository;
            _requestsRepository = requestsRepository;
            _peopleGroupsRepository = peopleGroupsRepository;
			_ideasCategoriesRepository = ideasCategoriesRepository;
		}

        public ApplicationDbContext Context { get => _context; set => _context = value; }

        public IRepository<ApplicationUser> ApplicationUsersRepository => _applicationUsersRepository;
        
        public IRepository<UserProfile> UserProfilesRepository => _userProfilesRepository;

        public IRepository<Idea> IdeasRepository => _ideasRepository;

        public IRepository<IdeaImage> IdeaImagesRepository => _ideaImagesRepository;

        public IRepository<AttachmentGroup> AttachmentsGroupsRepository => _attachmentsGroupsRepository;

        public IRepository<Attachment> AttachmentsRepository => _attachmentsRepository;

        public IRepository<Publication> PublicationsRepository => _publicationsRepository;

        public IRepository<PublicationImage> PublicationImagesRepository => _publicationImagesRepository;

        public IRepository<Image> ImagesRepository => _imagesRepository;

        public IRepository<Category> CategoriesRepository => _categoriesRepository;

        public IRepository<Request> RequestsRepository => _requestsRepository;

        public IRepository<PeopleGroup> PeopleGroupsRepository => _peopleGroupsRepository;

		public IRepository<IdeaCategory> IdeasCategoriesRepository => _ideasCategoriesRepository;

		public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
