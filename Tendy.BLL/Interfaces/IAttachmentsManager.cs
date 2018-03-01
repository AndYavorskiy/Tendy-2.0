using System.Collections.Generic;
using Tendy.BLL.ViewModels;

namespace Tendy.BLL.Interfaces
{
	public interface IAttachmentsManager
    {
		IEnumerable<LinkViewModel> GetLinks(int ideaId);

		bool UpdateLinks(int ideaId, IEnumerable<LinkViewModel> links);

		IEnumerable<FileViewModel> GetFiles(int ideaId);

		bool UpdateFile(int ideaId, IEnumerable<FileViewModel> links);
	}
}
