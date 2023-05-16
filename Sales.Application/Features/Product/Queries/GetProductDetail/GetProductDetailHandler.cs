using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Queries.GetProductDetail;
public class GetProductDetailHandler :
IRequestHandler<GetProductDetailQuery, ProductDetailDto>
{
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;

    public GetProductDetailHandler
    (
        IMapper mapper,
        IProductRepository productRepository
    )
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
    }

    public async Task<ProductDetailDto> Handle
    (
        GetProductDetailQuery request,
        CancellationToken cancellationToken
    )
    {
        var product = await productRepository.GetProductByIdWithDetails(request.Id);

        var data = mapper.Map<ProductDetailDto>(product);

        return data;
    }
}