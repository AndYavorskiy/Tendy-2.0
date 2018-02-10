using System;
using System.Collections.Generic;
using System.Text;

namespace Tendy.BLL.ViewModels
{
    public class FileViewModel 
    {
		public int Id { get; set; }

		public int AttachmentId { get; set; }

		public string Name { get; set; }

		public string Extension { get; set; }

		public string SourceUrl { get; set; }

		public string Source { get; set; }

		public bool IsPrivate { get; set; }

		public DateTime? DateOfCreation { get; set; }
	}
}
