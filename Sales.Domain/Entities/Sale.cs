using Sales.Domain.Common;

namespace Sales.Domain.Entities;
public class Sale : BaseEntity
{
  public int Amounth { get; set; }
  public DateTime SaleDate { get; set; }
  public int BillId { get; set; }
  public Bill? Bill { get; set; }
  public List<ProductSale>? ProductSales { get; set; }
  public List<Product>? Products { get; set; }
}