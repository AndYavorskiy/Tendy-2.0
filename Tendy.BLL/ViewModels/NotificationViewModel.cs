using System;

namespace Tendy.BLL.ViewModels
{
	public enum NotificationType
	{
		Informational,
		Success,
		Warning
	}

	public class NotificationViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Descriprtion { get; set; }
		public DateTime? DismissedDate { get; set; }
		public NotificationType Type { get; set; }
		public string UserId { get; set; }
	}
}