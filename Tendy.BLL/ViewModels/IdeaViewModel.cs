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

        public DateTime? DateOfCreation { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUserViewModel Author { get; set; }

        public int? AttachmentGroupId { get; set; }

        public AttachmentGroupViewModel AttachmentGroup { get; set; }

        public int? AcceptedPeopleGroupId { get; set; }

        public PeopleGroupViewModel AcceptedPeopleGroup { get; set; }

        public int? RequestedPeopleGroupId { get; set; }

        public PeopleGroupViewModel RequestedPeopleGroup { get; set; }

        public ICollection<IdeaCategoryViewModel> IdeaCategories { get; set; }

        public ICollection<PublicationViewModel> Publications { get; set; }

        public ICollection<IdeaImageViewModel> IdeaImages { get; set; }
    }
}
