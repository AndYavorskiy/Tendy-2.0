using FluentValidation.Attributes;
using Tendy.BLL.Utils.Validations;

namespace Tendy.BLL.ViewModels
{
    [Validator(typeof(RegistrationViewModelValidator))]
    public class RegistrationViewModel
    {
        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual string PhoneNumber { get; set; }
    }
}