using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using Sales.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sale.Commands.CreateSale;
public class CreateSaleCommandHandler :
IRequestHandler<CreateSaleCommand, int>
{
  private readonly IMapper mapper;
  private readonly ISaleRepository saleRepository;
  private readonly IProductRepository productRepository;

  public CreateSaleCommandHandler
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

  public int MyProperty { get; set; }

  public async Task<int> Handle
  (
    CreateSaleCommand request,
    CancellationToken cancellationToken
  )
  {
    var validator = new CreateSaleCommandValidator(saleRepository, productRepository);
    var validationResult = await validator.ValidateAsync( request );

    if(validationResult.Errors.Any())
      throw new BadRequestException("Invalid Sale", validationResult);

    var saleToCreate = mapper.Map<Domain.Entities.Sale>( request );

    await saleRepository.CreateAsync(saleToCreate);

    return saleToCreate.Id;
  }
}
