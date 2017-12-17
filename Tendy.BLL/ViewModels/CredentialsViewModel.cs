using FluentValidation.Attributes;
using Tendy.BLL.Utils.Validations;

namespace Tendy.BLL.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}