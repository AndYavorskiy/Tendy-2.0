using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Tendy.Abstract;
using Tendy.BLL.Interfaces;
using Tendy.BLL.ViewModels;
using Tendy.Common.Exceptions;

namespace Tendy.BLL.Managers
{
	public class NotificationManager : INotificationManager
	{
		readonly IUnitOfWork uow;

		public NotificationManager(IUnitOfWork uow)
		{
			this.uow = uow;
		}

		public IEnumerable<NotificationViewModel> GetActiveNotifications(string userId)
		{
			return uow.NotificationRepository
				.FindBy(notif => notif.UserId == userId && notif.DismissedDate == null)
				.Select(notif => new NotificationViewModel()
				{
					Id = notif.Id,
					Title = notif.Title,
					Descriprtion = notif.Descriprtion,
					DismissedDate = notif.DismissedDate,
					Type = (NotificationType) notif.Type,
					UserId = notif.UserId
				});
		}

		public void Dismiss(int notificationId, string userId)
		{
			var notific = uow.NotificationRepository
				.FindBy(notification => notification.Id == notificationId
					&& notification.UserId == userId)
				.FirstOrDefault();

			if (notific != null)
			{
				notific.DismissedDate = DateTime.UtcNow;

				uow.NotificationRepository.Update(notific);

				uow.SaveChanges();
			}
			else
			{
				throw new CustomException(StatusCodes.Status405MethodNotAllowed, ExceptionsMessages.CannotDismissNotification);
			}
		}

		public void Notify(NotificationViewModel notification)
		{
			uow.NotificationRepository
				.Create(new DAL.Entities.Notification()
				{
					Title = notification.Title,
					Descriprtion = notification.Descriprtion,
					Type = (DAL.Entities.NotificationType) notification.Type,
					UserId = notification.UserId
				});
		}
	}
}
