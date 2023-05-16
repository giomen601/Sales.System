using AutoMapper;
using Sales.Application.Features.Product.Queries.GetAllProducts;
using Sales.Application.Features.Sale.Commands.CreateSale;
using Sales.Application.Features.Sale.Commands.UpdateSale;
using Sales.Application.Features.Sale.Queries.GetAllSales;
using Sales.Application.Features.Sale.Queries.GetSaleDetail;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.MappingProfile;
public class SaleProfile : Profile
{
  public SaleProfile()
  {
    CreateMap<SaleDto, Sale>();
    CreateMap<Sale, SaleDto>()
    .ForMember(productDto => productDto.Products,
    options => options.MapFrom(MapSaleDtoProducts));

    CreateMap<SaleDetailDto, Sale>();
    CreateMap<Sale, SaleDetailDto>()
    .ForMember(productDto => productDto.Products,
    options => options.MapFrom(MapSaleDtoProduct));

    CreateMap<CreateSaleCommand, Sale>()
    .ForMember(product => product.ProductSales,
    options => options.MapFrom(MapProductSales));

    CreateMap<UpdateSaleCommand, Sale>();
  }

  private List<ProductDto> MapSaleDtoProduct(Sale sale, SaleDetailDto saleDto)
  {
    var result = new List<ProductDto>();

    if (sale.ProductSales == null) return result;

    foreach (var productsale in sale.ProductSales)
    {
      result.Add(new ProductDto()
      {
        Description = productsale.Products?.Description,
        Price = (double)(productsale.Products?.Price)
      });
    }

    return result;
  }

  private List<ProductDto> MapSaleDtoProducts(Sale sale, SaleDto saleDto)
  {
    var result = new List<ProductDto>();

    if(sale.ProductSales == null) return result;

    foreach (var productsale in sale.ProductSales)
    {
      result.Add(new ProductDto()
      {
        Description = productsale.Products?.Description,
        Price = (double)(productsale.Products?.Price)
      });
    }

    return result;
  }

  private List<ProductSale>
  MapProductSales(CreateSaleCommand createSaleCommand, Sale sale)
  {
    var result = new List<ProductSale>();

    if(createSaleCommand.ProductsId == null) return result;

    foreach (var productId in createSaleCommand.ProductsId)
    {
     result.Add(new ProductSale() { ProductId = productId });       
    }

    return result;
  }
}
