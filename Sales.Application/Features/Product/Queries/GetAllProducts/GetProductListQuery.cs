using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Queries.GetAllProducts;
public record GetProductListQuery : IRequest<List<ProductDto>>;