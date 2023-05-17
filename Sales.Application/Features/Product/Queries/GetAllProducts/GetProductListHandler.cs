using AutoMapper;
using MediatR;
using Sales.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Queries.GetAllProducts;
public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
{
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;

    public GetProductListHandler
    (
        IMapper mapper,
        IProductRepository productRepository
    )
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
    }

    public async Task<List<ProductDto>> Handle
    (
        GetProductListQuery request,
        CancellationToken cancellationToken
    )
    {
        var products = await productRepository.GetProductsWithDetails();

        var data = mapper.Map<List<ProductDto>>(products);

        return data;
    }
}