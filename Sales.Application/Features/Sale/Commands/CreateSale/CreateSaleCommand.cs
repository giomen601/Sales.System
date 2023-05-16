using MediatR;

namespace Sales.Application.Features.Sale.Commands.CreateSale;
public class CreateSaleCommand : IRequest<int>
{
  public int Amounth { get; set; }
  public DateTime SaleDate { get; set; }
  public int BillId { get; set; }
  public List<int>? ProductsId { get; set; }
}
