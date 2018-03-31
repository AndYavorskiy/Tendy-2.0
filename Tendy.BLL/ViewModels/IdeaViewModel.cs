using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using Tendy.BLL.Utils.Validations;

namespace Tendy.BLL.ViewModels
{
	[Validator(typeof(IdeaViewModelValidator))]
	public class IdeaViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string SubTitle { get; set; }

		public string Description { get; set; }

		public string GitHubLink { get; set; }

		public DateTime? DateOfCreation { get; set; }

		public bool IsUserJoined { get; set; }

		public string AuthorId { get; set; }
		public ApplicationUserViewModel Author { get; set; }

		public ICollection<RequestViewModel> Request { get; set; }

		public ICollection<IdeaCategoryViewModel> IdeaCategories { get; set; }

		public ICollection<LinkViewModel> Links { get; set; }

		public IEnumerable<FileViewModel> Files { get; set; }

	}
}
