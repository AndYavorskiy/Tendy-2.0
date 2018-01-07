using System.Collections.Generic;

namespace Tendy.Common.ViewModels
{
	public class AggregateContent<T> where T : class
	{
		public int Total { get; set; }
		public IEnumerable<T> Source { get; set; }
	}
}