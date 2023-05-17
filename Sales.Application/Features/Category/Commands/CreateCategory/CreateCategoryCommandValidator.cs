using FluentValidation;
using Sales.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Category.Commands.CreateCategory;
public class CreateCategoryCommandValidator :
AbstractValidator<CreateCategoryCommand>
{
  private readonly ICategoryRepository categoryRepository;

  public CreateCategoryCommandValidator
  (
    ICategoryRepository categoryRepository
  )
  {
    this.categoryRepository = categoryRepository;

    RuleFor(x => x.Description)
    .NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull()
    .MaximumLength(45).WithMessage("{PropertyName} must be fewer than 45 character");
  }
}
