using AutoMapper;
using MediatR;
using Sales.Application.Contracts.Persistence;
using Sales.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sale.Commands.UpdateSale;
public class UpdateSaleCommandHandler :
IRequestHandler<UpdateSaleCommand, Unit>
{
  private readonly IMapper mapper;
  private readonly ISaleRepository saleRepository;
  private readonly IProductRepository productRepository;

  public UpdateSaleCommandHandler
  (
    IMapper mapper,
    ISaleRepository saleRepository,
    IProductRepository productRepository
  )
  {
    this.mapper = mapper;
    this.saleRepository = saleRepository;
    this.productRepository = productRepository;
  }

  public async Task<Unit> Handle
  (
    UpdateSaleCommand request,
    CancellationToken cancellationToken
  )
  {
    var validator = new UpdateSaleCommandValidator(productRepository);
    var validationResult = await validator.ValidateAsync( request );

    if (validationResult.Errors.Any())
      throw new BadRequestException("Invalid Sale", validationResult);

    var sale = await saleRepository.GetByIdAsync(request.Id);

    mapper.Map(request, sale);

    await saleRepository.UpdateSalesWithProducts(sale, request);

    return Unit.Value;
  }
}
