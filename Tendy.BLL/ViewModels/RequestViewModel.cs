using System;

namespace Tendy.BLL.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUserViewModel ApplicationUser { get; set; }

        public int? PeopleGroupId { get; set; }

        public PeopleGroupViewModel PeopleGroup { get; set; }

        public DateTime? DateOfJoining { get; set; }
    }
}
