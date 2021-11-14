using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.ADAA.Application.Features.Categories.Commands.DeleteCategory
{
    class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(p => p.CATEGORY_ID)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
