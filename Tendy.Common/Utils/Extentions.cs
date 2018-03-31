using System;
using System.Collections.Generic;
using System.Text;

namespace Tendy.Common.Utils
{
	public static class Extentions
	{
		public static bool GetValueOrDefault(this bool? variable)
		{
			return variable ?? default(bool);
		}
	}
}
