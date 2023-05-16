using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Commands.CreateProduct;
public class CreateProductCommand : IRequest<int>
{
    public string? Description { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
    //public List<int> CategoriesId { get; set; }
}