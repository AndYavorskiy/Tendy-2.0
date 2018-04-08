using System.Collections.Generic;
using Tendy.BLL.ViewModels;

namespace Tendy.BLL.Interfaces
{
	public interface IRequestManager
    {
		bool UpdateJoinRequest(int ideaId, string userId);
		IEnumerable<RequestViewModel> GetRequests(int? ideaId);
		bool ConfirmRequest(int ideaId, int requestId,string userId, string managerId);
	}
}