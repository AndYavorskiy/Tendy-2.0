using System;
using System.Collections.Generic;
using System.Text;

namespace Tendy.BLL.ViewModels
{
	public class LinkViewModel
	{
		public int Id { get; set; }

		public int AttachmentId { get; set; }

		public string Url { get; set; }

		public bool IsPrivate { get; set; }

		public DateTime? DateOfCreation { get; set; }
	}
}
