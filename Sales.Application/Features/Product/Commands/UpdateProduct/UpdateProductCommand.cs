using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Commands.UpdateProduct;
public class UpdateProductCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
}