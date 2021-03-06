﻿using Tendy.DAL.Abstract;
using Tendy.DAL.Entities;

namespace Tendy.Abstract
{
	public interface IUnitOfWork
	{
		IRepository<ApplicationUser> ApplicationUsersRepository { get; }
		IRepository<UserProfile> UserProfilesRepository { get; }
		IRepository<Idea> IdeasRepository { get; }
		IRepository<IdeaCategory> IdeasCategoriesRepository { get; }
		IRepository<Category> CategoriesRepository { get; }
		IRepository<Request> RequestsRepository { get; }
		IRepository<Link> LinksRepository { get; }
		IRepository<File> FilesRepository { get; }
		IRepository<AccountSettings> AccountCofigurationRepository { get; }
		IRepository<Notification> NotificationRepository { get; }

		void SaveChanges();
	}
}
