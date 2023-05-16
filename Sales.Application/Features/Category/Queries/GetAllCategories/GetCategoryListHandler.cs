using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Category.Queries.GetAllCategories;
public class GetCategoryListHandler :
IRequestHandler<GetCategoryListQuery, List<CategoryDto>>
{
  private readonly IMapper mapper;
  private readonly ICategoryRepository categoryRepository;

  public GetCategoryListHandler
  (
    IMapper mapper,
    ICategoryRepository categoryRepository
  )
  {
    this.mapper = mapper;
    this.categoryRepository = categoryRepository;
  }

  public async Task<List<CategoryDto>> Handle
  (
  GetCategoryListQuery request,
  CancellationToken cancellationToken
  )
  {
    var categories = await categoryRepository.GetCategoryWhitProducts();
    var data = mapper.Map<List<CategoryDto>>( categories );
    return data;
  }
}
