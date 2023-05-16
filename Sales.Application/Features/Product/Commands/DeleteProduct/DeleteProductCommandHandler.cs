using MediatR;
using Sales.Application.Contacts.Persistence;
using Sales.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Commands.DeleteProduct;
public class DeleteProductCommandHandler :
    IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository productRepository;

    public DeleteProductCommandHandler
    (
        IProductRepository productRepository
    )
    {
        this.productRepository = productRepository;
    }
    public async Task<Unit> Handle
    (
        DeleteProductCommand request,
        CancellationToken cancellationToken
    )
    {
        var productToDelete = await productRepository.GetByIdAsync(request.Id);

        //Verify if that record exist
        if(productToDelete == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        await productRepository.DeleteAsync(productToDelete);

        //return record id
        return Unit.Value;
    }
}