using FluentValidation;
using Sales.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Category.Commands.UpdateCategory;
public class UpdateCategoryCommandValidator :
AbstractValidator<UpdateCategoryCommand>
{
  public UpdateCategoryCommandValidator
  (
    
  )
  {

    RuleFor(x => x.Id)
    .NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull();

    RuleFor(x => x.Description)
    .NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull()
    .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 character");
  }
}
