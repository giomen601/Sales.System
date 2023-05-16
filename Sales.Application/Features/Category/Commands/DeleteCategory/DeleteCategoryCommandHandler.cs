using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using Sales.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Category.Commands.DeleteCategory;
public class DeleteCategoryCommandHandler :
IRequestHandler<DeleteCategoryCommand>
{
  private readonly IMapper mapper;
  private readonly ICategoryRepository categoryRepository;

  public DeleteCategoryCommandHandler
  (
    IMapper mapper,
    ICategoryRepository categoryRepository
  )
  {
    this.mapper = mapper;
    this.categoryRepository = categoryRepository;
  }
  public async Task<Unit> Handle
  (
    DeleteCategoryCommand request,
    CancellationToken cancellationToken
  )
  {
    var category = await categoryRepository.GetByIdAsync(request.Id);

    if(category == null)
      throw new NotFoundException(nameof(category), request.Id);

    await categoryRepository.DeleteAsync(category);
    return Unit.Value;
  }
}