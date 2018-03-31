using Tendy.BLL.ViewModels;
using Tendy.Common.ViewModels;

namespace Tendy.BLL.Interfaces
{
	public interface IManageIdeasService
    {
		bool UpdateJoinRequest(int ideaId, string userId);


	}
}