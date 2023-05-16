using FluentValidation;
using Sales.Application.Contacts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Commands.UpdateProduct;
public class UpdateProductCommandValidator :
    AbstractValidator<UpdateProductCommand>
{
    private readonly IProductRepository productRepository;

    public UpdateProductCommandValidator
    (
        IProductRepository productRepository
    )
    {
        this.productRepository = productRepository;

        RuleFor(x => x.Id)
        .NotEmpty()
        .WithMessage("{PropertyName} couldn't be empty")
        .NotNull();

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
    }
}