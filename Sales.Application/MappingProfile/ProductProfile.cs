using AutoMapper;
using Sales.Application.Features.Product.Commands.CreateProduct;
using Sales.Application.Features.Product.Commands.UpdateProduct;
using Sales.Application.Features.Product.Queries.GetAllProducts;
using Sales.Application.Features.Product.Queries.GetProductDetail;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.MappingProfile;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();

        CreateMap<ProductDetailDto, Product>().ReverseMap();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}