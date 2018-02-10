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

		public string AuthorId { get; set; }
		public virtual ApplicationUserViewModel Author { get; set; }

		public int? AcceptedPeopleGroupId { get; set; }
		public virtual PeopleGroupViewModel AcceptedPeopleGroup { get; set; }

		public int? RequestedPeopleGroupId { get; set; }
		public virtual PeopleGroupViewModel RequestedPeopleGroup { get; set; }

		public virtual AttachmentViewModel Attachment { get; set; }
		public virtual ICollection<IdeaCategoryViewModel> IdeaCategories { get; set; }
	}
}
