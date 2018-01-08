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

        public int? AttachmentGroupId { get; set; }
        public virtual AttachmentGroup AttachmentGroup { get; set; }

        public int? AcceptedPeopleGroupId { get; set; }
        [InverseProperty(nameof(PeopleGroup.IdeaAcceptedPeople))]
        public virtual PeopleGroup AcceptedPeopleGroup { get; set; }

        public int? RequestedPeopleGroupId { get; set; }
        [InverseProperty(nameof(PeopleGroup.IdeaRequestedPeople))]
        public virtual PeopleGroup RequestedPeopleGroup { get; set; }

        public virtual ICollection<IdeaCategory> IdeaCategories { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<IdeaImage> IdeaImages { get; set; }

        public Idea()
        {
            IdeaCategories = new List<IdeaCategory>();
            IdeaImages = new List<IdeaImage>();
            Publications = new List<Publication>();
        }
    }
}
