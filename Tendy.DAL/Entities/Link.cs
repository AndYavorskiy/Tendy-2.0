using System;

namespace Tendy.DAL.Entities
{
    public class Link
	{
		public int Id { get; set; }

		public int AttachmentId { get; set; }
		public virtual Attachment Attachment { get; set; }

		public string Url { get; set; }

		public bool IsPrivate { get; set; }

		public DateTime? DateOfCreation { get; set; }
	}
}