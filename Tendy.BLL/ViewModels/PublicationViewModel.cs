using System;
using System.Collections.Generic;

namespace Tendy.BLL.ViewModels
{
    public class PublicationViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime? DateOfCreation { get; set; }

        public int? IdeaId { get; set; }

        public IdeaViewModel Idea { get; set; }

        public ICollection<PublicationImageViewModel> PublicationImages { get; set; }

        public int? AttachmentGroupId { get; set; }
    }
}
