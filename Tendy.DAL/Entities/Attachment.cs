using System.Collections.Generic;

namespace Tendy.DAL.Entities
{
	public class Attachment
	{
		public int Id { get; set; }

		public int IdeaId { get; set; }
		public virtual Idea Idea { get; set; }

		public virtual ICollection<Link> Links { get; set; }

		public virtual ICollection<File> Files { get; set; }

		public Attachment()
		{
			Links = new List<Link>();
			Files = new List<File>();
		}
	}
}