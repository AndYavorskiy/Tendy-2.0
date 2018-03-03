using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Tendy.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile Profile { get; set; }

        public virtual AccountSettings AccountCofiguration { get; set; }

		public virtual ICollection<Idea> Ideas { get; set; }

        public ApplicationUser()
        {
            Ideas = new List<Idea>();
        }

    }
}
