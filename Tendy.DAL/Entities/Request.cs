using System;

namespace Tendy.DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }

		public bool? IsAccepted { get; set; }

		public bool? IsActive { get; set; }

		public string ApplicationUserId { get; set; }

		public virtual ApplicationUser ApplicationUser { get; set; }

		public int IdeaId { get; set; }
		public virtual Idea Idea { get; set; }

		public DateTime? DateOfJoining { get; set; }
    }
}
