using FluentValidation;
using Sales.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Commands.CreateProduct;
public class CreateProductCommandValidator : 
AbstractValidator<CreateProductCommand>
{
  private readonly IProductRepository productRepository;
  private readonly ICategoryRepository categoryRepository;

  public CreateProductCommandValidator
  (
      IProductRepository productRepository,
      ICategoryRepository categoryRepository
  )
  {
      this.productRepository = productRepository;
    this.categoryRepository = categoryRepository;
    RuleFor(x => x.Description)
    .NotEmpty()
    .WithMessage("{PropertyName} couldn't be empty")
    .NotNull()
    .MaximumLength(100)
    .WithMessage("{PropertyName} must be fewer than 100 characters");

    RuleFor(x => x.Price)
    .NotEmpty()
    .WithMessage("{PropertyName} couldn't be empty")
    .NotNull();

    RuleFor(x => x.CategoryId)
    .NotEmpty()
    .WithMessage("{PropertyName} couldn't be empty")
    .NotNull()
    .MustAsync(CategoryMustExist)
    .WithMessage("{PropertyName} must exist");
  }

  private async Task<bool> CategoryMustExist
  (
    int categoriId,
    CancellationToken arg2
  )
  {
    var category = await categoryRepository.GetByIdAsync(categoriId);
    if (category == null)
      return false;

    return true;
  }
}