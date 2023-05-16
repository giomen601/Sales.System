using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Features.Sale.Commands.CreateSale;
using Sales.Application.Features.Sale.Commands.DeleteSale;
using Sales.Application.Features.Sale.Commands.UpdateSale;
using Sales.Application.Features.Sale.Queries.GetAllSales;
using Sales.Application.Features.Sale.Queries.GetSaleDetail;

namespace Sales.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
  private readonly IMediator mediator;

  public SaleController
  (
    IMediator mediator  
  )
  {
    this.mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<List<SaleDto>>> Get()
  {
    var sales = await mediator.Send(new GetSalesListQuery());

    return Ok(sales);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<SaleDto>> Get(int id)
  {
    var sale = await mediator.Send(new GetSaleDetailQuery { Id = id });

    return Ok(sale);
  }

  [HttpPost]
  [ProducesResponseType(201)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<ActionResult> Post(CreateSaleCommand command)
  {
    var response = await mediator.Send(command);
    return CreatedAtAction(nameof(Get), new { id = response });
  }

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> Put(UpdateSaleCommand command)
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
    var commando = new DeleteSaleCommand { Id = id };
    await mediator.Send(commando);
    return NoContent();
  }
}