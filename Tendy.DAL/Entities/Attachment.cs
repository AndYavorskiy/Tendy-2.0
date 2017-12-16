using System;

namespace Tendy.DAL.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public string SourceUrl { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public bool? IsPrivate { get; set; }

        public int? AttachmentGroupId { get; set; }
        public virtual AttachmentGroup AttachmentGroup { get; set; }
    }
}
