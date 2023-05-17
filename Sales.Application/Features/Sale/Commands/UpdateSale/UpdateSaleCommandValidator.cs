using FluentValidation;
using Sales.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sale.Commands.UpdateSale;
public class UpdateSaleCommandValidator :
AbstractValidator<UpdateSaleCommand>
{
  private readonly IProductRepository productRepository;

  public UpdateSaleCommandValidator
  (
    IProductRepository productRepository
  )
  {
    RuleFor(x => x.Amounth)
    .NotEmpty()
    .WithMessage("Sale register couldn't be created without {PropertyName}")
    .NotNull();

    RuleFor(x => x.SaleDate)
    .NotEmpty()
    .WithMessage("{PropertyName} must be present")
    .NotNull();

    RuleFor(x => x.ProductsId)
    .NotEmpty()
    .WithMessage("Sale couldn't be created without {PropertyName}")
    .MustAsync(ProductsMustExist)
    .WithMessage("One or more {PropertyName} product doesn't exist in the data base");
    this.productRepository = productRepository;
  }

  private async Task<bool> ProductsMustExist
  (
    List<int> productsIds,
    CancellationToken arg2
  )
  {
    foreach (var productId in productsIds)
    {
      var product = await productRepository.GetByIdAsync(productId);

      if (product == null)
        return false;
    }
    return true;
  }
}
