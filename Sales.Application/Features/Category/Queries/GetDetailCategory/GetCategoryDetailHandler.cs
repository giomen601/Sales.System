using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Category.Queries.GetDetailCategory;
public class GetCategoryDetailHandler :
IRequestHandler<GetCategoryDetailQuery, CategoryDetailDto>
{
  private readonly IMapper mapper;
  private readonly ICategoryRepository categoryRepository;

  public GetCategoryDetailHandler
  (
    IMapper mapper,
    ICategoryRepository categoryRepository
  )
  {
  this.mapper = mapper;
    this.categoryRepository = categoryRepository;
  }
  public async Task<CategoryDetailDto> Handle
  (
  GetCategoryDetailQuery request,
  CancellationToken cancellationToken
  )
  {
    var category = await categoryRepository.GetCategoryWhitProducts ( request.Id );
    return mapper.Map<CategoryDetailDto>(category);
  }
}
