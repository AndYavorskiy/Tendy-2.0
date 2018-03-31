using System;

namespace Tendy.BLL.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }

		public bool? IsAccepted { get; set; }

		public string ApplicationUserId { get; set; }

        public ApplicationUserViewModel ApplicationUser { get; set; }

		public int IdeaId { get; set; }
		public IdeaViewModel Idea { get; set; }

        public DateTime? DateOfJoining { get; set; }
    }
}
