using Tendy.BLL.ViewModels;
using Tendy.Common.ViewModels;

namespace Tendy.BLL.Interfaces
{
	public interface IIdeasService
    {
		AggregateContent<IdeaViewModel> Search(IdeaSearchFilter filter);

		IdeaViewModel GetById(int id);

        IdeaViewModel Create(IdeaViewModel ideaVm);

        IdeaViewModel Update(IdeaViewModel ideaVm);

        bool Delete(int ideaId);
    }
}