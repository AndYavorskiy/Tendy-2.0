using FluentValidation;
using Tendy.BLL.ViewModels;

namespace Tendy.BLL.Utils.Validations
{
	public class IdeaViewModelValidator : AbstractValidator<IdeaViewModel>
	{
		public IdeaViewModelValidator()
		{
			RuleFor(vm => vm.Title)
				.NotEmpty().WithMessage("Title cannot be empty")
				.MinimumLength(5).WithMessage("Title cannot be less 5 symbols");

			RuleFor(vm => vm.Description)
				.NotEmpty().WithMessage("Description cannot be empty");
		}
	}
}
