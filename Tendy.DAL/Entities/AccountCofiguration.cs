using System;
using System.Collections.Generic;
using System.Text;

namespace Tendy.DAL.Entities
{
   public class AccountSettings
    {
		public int Id { get; set; }

		public bool IsAdminMode { get; set; }

		public virtual string ApplicationUserId { get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; }
	}
}
