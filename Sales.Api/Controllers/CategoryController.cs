using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Features.Category.Commands.CreateCategory;
using Sales.Application.Features.Category.Commands.DeleteCategory;
using Sales.Application.Features.Category.Commands.UpdateCategory;
using Sales.Application.Features.Category.Queries.GetAllCategories;
using Sales.Application.Features.Category.Queries.GetDetailCategory;

namespace Sales.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
  private readonly IMediator mediator;
  public CategoryController
  (
    IMediator mediator
  )
  {
    this.mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<List<CategoryDto>>> Get()
  {
    var categories = await mediator.Send(new GetCategoryListQuery());
    return Ok(categories);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<CategoryDto>> Get(int id)
  {
    var category = await mediator.Send(new GetCategoryDetailQuery { Id = id });
    return Ok(category);
  }

  [HttpPost]
  [ProducesResponseType(201)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<ActionResult> Post(CreateCategoryCommand command)
  {
    var response = await mediator.Send(command);
    return CreatedAtAction(nameof(Get), new { id = response });
  }

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> Put(UpdateCategoryCommand command)
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
    var command = new DeleteCategoryCommand { Id = id };
    await mediator.Send(command);
    return NoContent();
  }
}
