using System;

namespace Tendy.DAL.Entities
{
    public class Link 
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Url { get; set; }

		public bool IsPrivate { get; set; }

		public int IdeaId { get; set; }
		public virtual Idea Idea { get; set; }

		public DateTime? DateOfCreation { get; set; }
	}
}