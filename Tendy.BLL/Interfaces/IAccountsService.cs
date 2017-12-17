using System.Threading.Tasks;
using Tendy.BLL.ViewModels;

namespace Tendy.BLL.Interfaces
{
    public interface IAccountsService
    {
        Task<RegistrationViewModel> Create(RegistrationViewModel regModel);
    }
}
