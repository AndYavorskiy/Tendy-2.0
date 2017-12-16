using System;
using System.Collections.Generic;

namespace Tendy.DAL.Entities
{
    public class Publication
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfCreation { get; set; }

        public int? IdeaId { get; set; }
        public virtual Idea Idea { get; set; }

        public virtual ICollection<PublicationImage> PublicationImages { get; set; }

        public int? AttachmentGroupId { get; set; }
        public virtual AttachmentGroup AttachmentGroup { get; set; }

        public Publication()
        {
            PublicationImages = new List<PublicationImage>();
        }
    }
}
