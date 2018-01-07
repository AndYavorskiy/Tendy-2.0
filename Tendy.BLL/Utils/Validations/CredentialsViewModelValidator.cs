using FluentValidation;
using Tendy.BLL.ViewModels;

namespace Tendy.BLL.Utils.Validations
{
	public class CredentialsViewModelValidator : AbstractValidator<CredentialsViewModel>
	{
		public CredentialsViewModelValidator()
		{
			RuleFor(vm => vm.Email)
			.NotEmpty().WithMessage("Email cannot be empty");

			RuleFor(vm => vm.Password)
				  .NotEmpty().WithMessage("Password cannot be empty")
				  .MinimumLength(5).WithMessage("Password cannot be less 5 symbols");
		}
	}
}