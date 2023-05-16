using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using Sales.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Commands.CreateProduct;
public class CreateProductCommandHandle :
    IRequestHandler<CreateProductCommand, int>
{
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;
  private readonly ICategoryRepository categoryRepository;

  public CreateProductCommandHandle
    (
        IMapper mapper,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository
    )
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
        this.categoryRepository = categoryRepository;
    }
    public async Task<int> Handle
    (
        CreateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        var validator = new CreateProductCommandValidator(productRepository, categoryRepository);
        var validationResult = await validator.ValidateAsync(request);

        if(validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid book", validationResult);
        }

        var productToCreate = mapper.Map<Domain.Entities.Product>(request);

        await productRepository.CreateAsync(productToCreate);

        return productToCreate.Id;
    }
}