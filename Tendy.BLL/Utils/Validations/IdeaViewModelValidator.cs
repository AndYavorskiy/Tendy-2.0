using FluentValidation;
using System;
using System.Collections.Generic;
using Tendy.BLL.ViewModels;

namespace Tendy.BLL.Utils.Validations
{
    public class IdeaViewModelValidator : AbstractValidator<IdeaViewModel>
    {
        public IdeaViewModelValidator()
        {
            RuleFor(vm => vm.Title).NotEmpty().MinimumLength(5).WithMessage("Title cannot be empty");
            RuleFor(vm => vm.Description).NotEmpty().WithMessage("Description cannot be empty");
        }
    }
}
