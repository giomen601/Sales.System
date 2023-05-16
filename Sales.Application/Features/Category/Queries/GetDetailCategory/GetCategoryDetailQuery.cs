using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Category.Queries.GetDetailCategory;
public class GetCategoryDetailQuery : IRequest<CategoryDetailDto>
{
    public int Id { get; set; }
}
