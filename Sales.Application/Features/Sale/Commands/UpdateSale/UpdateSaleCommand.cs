using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sale.Commands.UpdateSale;
public class UpdateSaleCommand : IRequest<Unit>
{
  public int Id { get; set; }
  public int Amounth { get; set; }
  public DateTime SaleDate { get; set; }
  public int BillId { get; set; }
  public List<int>? ProductsId { get; set; }
}
