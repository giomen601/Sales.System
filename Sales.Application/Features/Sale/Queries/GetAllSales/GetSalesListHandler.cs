using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sale.Queries.GetAllSales;
public class GetSalesListHandler :
  IRequestHandler<GetSalesListQuery, List<SaleDto>>
{
  private readonly IMapper mapper;
  private readonly ISaleRepository saleRepository;

  public GetSalesListHandler
  (
    IMapper mapper,
    ISaleRepository saleRepository
  )
  {
    this.mapper = mapper;
    this.saleRepository = saleRepository;
  }
  public async Task<List<SaleDto>> Handle
  (
    GetSalesListQuery request,
    CancellationToken cancellationToken
  )
  {
    var sales = await saleRepository.GetSalesWithProducts();

    var data = mapper.Map<List<SaleDto>>(sales);

    return data;
  }
}
