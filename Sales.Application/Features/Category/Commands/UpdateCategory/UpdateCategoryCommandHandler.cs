using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using Sales.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Category.Commands.UpdateCategory;
public class UpdateCategoryCommandHandler :
IRequestHandler<UpdateCategoryCommand, Unit>
{
  private readonly IMapper mapper;
  private readonly ICategoryRepository categoryRepository;

  public UpdateCategoryCommandHandler
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
    UpdateCategoryCommand request,
    CancellationToken cancellationToken
  )
  {
    var validator = new UpdateCategoryCommandValidator();
    var validationResult = await validator.ValidateAsync(request);

    if (validationResult.Errors.Any())
      throw new BadRequestException("Invalid category", validationResult);

    var category = await categoryRepository.GetByIdAsync(request.Id);

    if (category == null)
      throw new NotFoundException(nameof(category), request.Id);

    mapper.Map(request, category);
    await categoryRepository.UpdateAsync(category);
    return Unit.Value;
  }
}
