using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tendy.DAL.Entities
{
	public class Idea
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string SubTitle { get; set; }

		public string Description { get; set; }

		public string GitHubLink { get; set; }

		public DateTime? DateOfCreation { get; set; }

		public string AuthorId { get; set; }
		public virtual ApplicationUser Author { get; set; }

		public virtual ICollection<Request> Request { get; set; }

		public virtual ICollection<IdeaCategory> IdeaCategories { get; set; }

		public virtual ICollection<Link> Links { get; set; }

		public virtual ICollection<File> Files { get; set; }

		public Idea()
		{
			IdeaCategories = new List<IdeaCategory>();
			Links = new List<Link>();
			Files = new List<File>();
			Request = new List<Request>();
		}
	}
}
