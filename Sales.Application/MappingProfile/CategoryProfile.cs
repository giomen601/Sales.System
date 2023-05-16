using AutoMapper;
using Sales.Application.Features.Category.Commands.CreateCategory;
using Sales.Application.Features.Category.Commands.UpdateCategory;
using Sales.Application.Features.Category.Queries.GetAllCategories;
using Sales.Application.Features.Category.Queries.GetDetailCategory;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.MappingProfile;
public class CategoryProfile : Profile
{
  public CategoryProfile()
  {
    CreateMap<CategoryDto, Category>().ReverseMap();
    CreateMap<CategoryDetailDto, Category>().ReverseMap();

    CreateMap<CreateCategoryCommand, Category>();
    CreateMap<UpdateCategoryCommand, Category>();

  }
}
