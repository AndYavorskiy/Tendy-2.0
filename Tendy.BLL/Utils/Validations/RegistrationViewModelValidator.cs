using FluentValidation;
using Tendy.BLL.ViewModels;

namespace Tendy.BLL.Utils.Validations
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(vm => vm.UserName)
					.NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(vm => vm.Email)
					.EmailAddress()
					.NotEmpty().WithMessage("Email cannot be empty");

            RuleFor(vm => vm.Password)
					.NotEmpty().WithMessage("Password cannot be empty")
					.MinimumLength(5).WithMessage("Password cannot be less 5 symbols");
        }
    }
}