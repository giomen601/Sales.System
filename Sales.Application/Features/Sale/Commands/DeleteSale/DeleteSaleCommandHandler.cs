using AutoMapper;
using MediatR;
using Sales.Application.Contracts.Persistence;
using Sales.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sale.Commands.DeleteSale;
public class DeleteSaleCommandHandler :
IRequestHandler<DeleteSaleCommand>
{
  private readonly IMapper mapper;
  private readonly ISaleRepository saleRepository;

  public DeleteSaleCommandHandler
  (
    IMapper mapper,
    ISaleRepository saleRepository
  )
  {
    this.mapper = mapper;
    this.saleRepository = saleRepository;
  }

  public async Task<Unit> Handle
  (
    DeleteSaleCommand request,
    CancellationToken cancellationToken
  )
  {
    var sale = await saleRepository.GetByIdAsync(request.Id);

    if (sale == null)
      throw new NotFoundException(nameof(sale), request.Id);

    await saleRepository.DeleteAsync(sale);

    return Unit.Value;
  }
}
