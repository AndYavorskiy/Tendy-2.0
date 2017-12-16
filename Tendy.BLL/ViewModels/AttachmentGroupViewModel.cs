using System.Collections.Generic;

namespace Tendy.BLL.ViewModels
{
    public class AttachmentGroupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IdeaViewModel Idea { get; set; }

        public PublicationViewModel Publication { get; set; }

        public ICollection<AttachmentViewModel> Attachments { get; set; }
    }
}