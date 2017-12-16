using System;

namespace Tendy.DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int? PeopleGroupId { get; set; }
        public virtual PeopleGroup PeopleGroup { get; set; }

        public DateTime? DateOfJoining { get; set; }
    }
}
