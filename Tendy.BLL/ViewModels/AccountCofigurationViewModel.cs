using System;
using System.Collections.Generic;
using System.Text;

namespace Tendy.BLL.ViewModels
{
   public class AccountSettingsViewModel
    {
		public int Id { get; set; }

		public bool IsAdminMode { get; set; }

		public virtual string ApplicationUserId { get; set; }
	}
}
