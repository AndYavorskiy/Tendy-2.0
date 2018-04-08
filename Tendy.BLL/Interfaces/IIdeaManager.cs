using Tendy.BLL.ViewModels;
using Tendy.Common.ViewModels;

namespace Tendy.BLL.Interfaces
{
	public interface IIdeaManager
    {
		AggregateContent<IdeaViewModel> Search(IdeaSearchFilter filter);

		IdeaViewModel Get(int id, string userId);

        IdeaViewModel Create(IdeaViewModel ideaVm);

        IdeaViewModel Update(IdeaViewModel ideaVm);

        bool Delete(int ideaId);
    }
}