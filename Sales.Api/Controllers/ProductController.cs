using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Features.Product.Commands.CreateProduct;
using Sales.Application.Features.Product.Commands.DeleteProduct;
using Sales.Application.Features.Product.Commands.UpdateProduct;
using Sales.Application.Features.Product.Queries.GetAllProducts;
using Sales.Application.Features.Product.Queries.GetProductDetail;
using Sales.Domain.Entities;

namespace Sales.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
  private readonly IMediator mediator;

  public ProductController(IMediator mediator)
  {
    this.mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<List<ProductDto>>> Get()
  {
    var products = await mediator.Send(new GetProductListQuery());
    return Ok(products);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ProductDto>> Get(int id)
  {
    var product = await mediator.Send(new GetProductDetailQuery { Id = id });
    return Ok(product);
  }

  [HttpPost]
  [ProducesResponseType(201)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<ActionResult> Post(CreateProductCommand command)
  {
    var response = await mediator.Send(command);
    return CreatedAtAction(nameof(Get), new { id = response });
  }

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> Put(UpdateProductCommand command)
  {
    await mediator.Send(command);
    return NoContent();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> Delete(int id)
  {
    var command = new DeleteProductCommand { Id = id };
    await mediator.Send(command);
    return NoContent();
  }
}