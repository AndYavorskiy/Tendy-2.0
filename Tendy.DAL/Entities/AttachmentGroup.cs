using System.Collections.Generic;

namespace Tendy.DAL.Entities
{
    public class AttachmentGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Idea Idea { get; set; }
        public virtual Publication Publication { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }

        public AttachmentGroup()
        {
            Attachments = new List<Attachment>();
        }

    }
}