using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sale.Queries.GetSaleDetail;
public class GetSaleDetailHandler :
IRequestHandler<GetSaleDetailQuery, SaleDetailDto>
{
  private readonly IMapper mapper;
  private readonly ISaleRepository saleRepository;

  public GetSaleDetailHandler
  (
    IMapper mapper,
    ISaleRepository saleRepository
  )
  {
    this.mapper = mapper;
    this.saleRepository = saleRepository;
  }

  public async Task<SaleDetailDto> Handle
  (
    GetSaleDetailQuery request,
    CancellationToken cancellationToken
  )
  {
    var sale = await saleRepository.GetSalesByIdWhitProducts(request.Id);

    var data = mapper.Map<SaleDetailDto>(sale);

    return data;
  }
}
