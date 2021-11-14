using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.ADAA.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(p => p.CATEGORY_NAME_AR)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.CATEGORY_NAME_EN)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.CATEGORY_DEPARTMENT_ID)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
