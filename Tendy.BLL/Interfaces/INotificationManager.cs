using System;
using System.Collections.Generic;
using System.Text;
using Tendy.BLL.ViewModels;

namespace Tendy.BLL.Interfaces
{
    public interface INotificationManager
    {
		IEnumerable<NotificationViewModel> GetActiveNotifications(string userId);
		void Notify(NotificationViewModel notification);
		void Dismiss(int notificationId, string userId);
	}
}
