﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Queries.GetProductDetail;
public class GetProductDetailQuery : IRequest<ProductDetailDto>
{
    public int Id { get; set; }
}