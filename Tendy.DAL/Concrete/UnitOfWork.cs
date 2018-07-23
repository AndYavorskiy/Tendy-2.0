using Tendy.DAL.Abstract;
using Tendy.DAL.EF;
using Tendy.DAL.Entities;
using Tendy.Abstract;

namespace Tendy.Concrete
{
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(
			ApplicationDbContext context,
			IRepository<ApplicationUser> applicationUsersRepository,
			IRepository<UserProfile> userProfilesRepository,
			IRepository<Idea> ideasRepository,
			IRepository<Category> categoriesRepository,
			IRepository<Request> requestsRepository,
			IRepository<IdeaCategory> ideasCategoriesRepository,
			IRepository<Link> linksRepository,
			IRepository<File> filesRepository,
			IRepository<AccountSettings> accountCofigurationRepository,
			IRepository<Notification> notificationRepository)
		{
			Context = context;
			ApplicationUsersRepository = applicationUsersRepository;
			UserProfilesRepository = userProfilesRepository;
			IdeasRepository = ideasRepository;
			CategoriesRepository = categoriesRepository;
			RequestsRepository = requestsRepository;
			IdeasCategoriesRepository = ideasCategoriesRepository;
			LinksRepository = linksRepository;
			FilesRepository = filesRepository;
			AccountCofigurationRepository = accountCofigurationRepository;
			NotificationRepository = notificationRepository;
		}

		public ApplicationDbContext Context { get; private set; }

		public IRepository<ApplicationUser> ApplicationUsersRepository { get; private set; }

		public IRepository<UserProfile> UserProfilesRepository { get; private set; }

		public IRepository<Idea> IdeasRepository { get; private set; }

		public IRepository<Category> CategoriesRepository { get; private set; }

		public IRepository<Request> RequestsRepository { get; private set; }

		public IRepository<IdeaCategory> IdeasCategoriesRepository { get; private set; }

		public IRepository<Link> LinksRepository { get; private set; }

		public IRepository<File> FilesRepository { get; private set; }

		public IRepository<AccountSettings> AccountCofigurationRepository { get; private set; }

		public IRepository<Notification> NotificationRepository { get; private set; }

		public void SaveChanges()
		{
			Context.SaveChanges();
		}
	}
}
