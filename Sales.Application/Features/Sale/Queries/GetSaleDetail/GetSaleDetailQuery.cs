using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sale.Queries.GetSaleDetail;
public class GetSaleDetailQuery : IRequest<SaleDetailDto>
{
  public int Id { get; set; }
}
