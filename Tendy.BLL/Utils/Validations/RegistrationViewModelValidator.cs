using FluentValidation;
using Tendy.BLL.ViewModels;

namespace Tendy.BLL.Utils.Validations
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(vm => vm.Email).EmailAddress().NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(vm => vm.PasswordHash).NotEmpty().MinimumLength(6).WithMessage("Password cannot be empty or less 6 symbols");
            RuleFor(vm => vm.UserName).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(vm => vm.PhoneNumber).NotEmpty().WithMessage("Phone Number cannot be empty");
        }
    }
}