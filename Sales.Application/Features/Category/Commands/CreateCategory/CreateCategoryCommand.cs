using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Category.Commands.CreateCategory;
public class CreateCategoryCommand : IRequest<Unit>
{
  public string? Description { get; set; }
}