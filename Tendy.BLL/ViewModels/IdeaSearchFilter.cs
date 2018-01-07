using System.Collections.Generic;

namespace Tendy.BLL.ViewModels
{
	public class IdeaSearchFilter : Common.ViewModels.SearchFilter
	{
		public bool IsUserAuthor { get; set; }
		public string AuthorId { get; set; }
		public IEnumerable<int> Categories { get; set; } = new List<int>();
	}
}
