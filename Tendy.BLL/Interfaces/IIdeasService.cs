using Tendy.BLL.ViewModels;
using System.Collections.Generic;

namespace Tendy.BLL.Interfaces
{
    public interface IIdeasService
    {
        IEnumerable<IdeaViewModel> GetAll();

        IdeaViewModel GetById(int id);

        IdeaViewModel Create(IdeaViewModel ideaVm);

        IdeaViewModel Update(IdeaViewModel ideaVm);

        bool Delete(int ideaId);
    }
}