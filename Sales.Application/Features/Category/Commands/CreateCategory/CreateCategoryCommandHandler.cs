using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using Sales.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Category.Commands.CreateCategory;
public class CreateCategoryCommandHandler :
IRequestHandler<CreateCategoryCommand, Unit>
{
  private readonly IMapper mapper;
  private readonly ICategoryRepository categoryRepository;

  public CreateCategoryCommandHandler
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
    CreateCategoryCommand request,
    CancellationToken cancellationToken
  )
  {
    var validator = new CreateCategoryCommandValidator(categoryRepository);
    var validationResult = await validator.ValidateAsync(request);

    if(validationResult.Errors.Any())
    {
      throw new BadRequestException("Inavlid category", validationResult);
    }

    var categoryToCreate = mapper.Map<Domain.Entities.Category>(request);

    await categoryRepository.CreateAsync(categoryToCreate);

    return Unit.Value;
  }
}
