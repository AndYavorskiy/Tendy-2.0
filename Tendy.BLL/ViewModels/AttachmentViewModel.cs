using System;
using System.Collections.Generic;

namespace Tendy.BLL.ViewModels
{
	public class AttachmentViewModel
	{
		public int Id { get; set; }

		public int IdeaId { get; set; }

		public virtual ICollection<LinkViewModel> Links { get; set; } = new List<LinkViewModel>();

		public virtual IEnumerable<FileViewModel> Files { get; set; } = new List<FileViewModel>();
	}
}
