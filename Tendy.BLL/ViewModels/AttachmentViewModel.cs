using System;

namespace Tendy.BLL.ViewModels
{
    public class AttachmentViewModel
    {
        public int Id { get; set; }

        public string SourceUrl { get; set; }

        public DateTime? DateOfCreation { get; set; }

        public bool? IsPrivate { get; set; }

        public int? AttachmentGroupId { get; set; }

        public AttachmentGroupViewModel AttachmentGroup { get; set; }
    }
}
