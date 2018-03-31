﻿using Tendy.DAL.Abstract;
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
		private readonly IRepository<Category> _categoriesRepository;
		private readonly IRepository<Request> _requestsRepository;
		private readonly IRepository<IdeaCategory> _ideasCategoriesRepository;
		private readonly IRepository<Link> _linksRepository;
		private readonly IRepository<File> _filesRepository;
		private readonly IRepository<AccountSettings> _accountCofigurationRepository;

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
			IRepository<AccountSettings> accountCofigurationRepository)
		{
			Context = context;
			_applicationUsersRepository = applicationUsersRepository;
			_userProfilesRepository = userProfilesRepository;
			_ideasRepository = ideasRepository;
			_categoriesRepository = categoriesRepository;
			_requestsRepository = requestsRepository;
			_ideasCategoriesRepository = ideasCategoriesRepository;
			_linksRepository = linksRepository;
			_filesRepository = filesRepository;
			_accountCofigurationRepository = accountCofigurationRepository;
		}

		public ApplicationDbContext Context { get => _context; set => _context = value; }

		public IRepository<ApplicationUser> ApplicationUsersRepository => _applicationUsersRepository;

		public IRepository<UserProfile> UserProfilesRepository => _userProfilesRepository;

		public IRepository<Idea> IdeasRepository => _ideasRepository;

		public IRepository<Category> CategoriesRepository => _categoriesRepository;

		public IRepository<Request> RequestsRepository => _requestsRepository;

		public IRepository<IdeaCategory> IdeasCategoriesRepository => _ideasCategoriesRepository;

		public IRepository<Link> LinksRepository => _linksRepository;

		public IRepository<File> FilesRepository => _filesRepository;

		public IRepository<AccountSettings> AccountCofigurationRepository => _accountCofigurationRepository;

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
