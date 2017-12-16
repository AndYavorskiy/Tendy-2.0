using Tendy.BLL.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Tendy.BLL.Interfaces
{
    public interface IIdeaService
    {
        IEnumerable<IdeaViewModel> GetAll();
        IdeaViewModel GetById(int id);
        IdeaViewModel Create(IdeaViewModel ideaVm);
        IdeaViewModel Update(IdeaViewModel ideaVm);
        bool Delete(int ideaId);
    }
}