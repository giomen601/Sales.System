using AutoMapper;
using MediatR;
using Sales.Application.Contacts.Persistence;
using Sales.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Commands.UpdateProduct;
public class UpdateProductCommandHandler :
IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;

    public UpdateProductCommandHandler
    (
        IMapper mapper,
        IProductRepository productRepository
    )
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
    }
    public async Task<Unit> Handle
    (
        UpdateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        var validator = new UpdateProductCommandValidator(productRepository);
        var validationResult = await validator.ValidateAsync( request );

        if(validationResult.Errors.Any())
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        var product = await productRepository.GetByIdAsync(request.Id);

        if(product == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        mapper.Map(request, product);

        await productRepository.UpdateAsync(product);

        return Unit.Value;
    }
}