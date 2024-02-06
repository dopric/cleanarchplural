using GloboTickets.Application.Features.Categories.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CategoryDto = GloboTickets.Application.Dtos.Events.CategoryDto;

namespace GloboTickets.TicketsManagement.Api.Controllers;

public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("all", Name = "GetAllCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType()]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
    {
        var categories = await _mediator.Send(new GetCategoryListQuery());
        return Ok(categories);
    }
    //
    // [HttpPost(Name = "AddCategory")]
    // [ProducesResponseType(StatusCodes.Status201Created)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<CreateCategoryCommandResponse>> AddCategory(
    //     [FromBody] CreateCategoryCommand createCategoryCommand)
    // {
    //     var response = await _mediator.Send(createCategoryCommand);
    //     return CreatedAtRoute("GetCategoryById", new { id = response.CategoryId }, response);
    // }
}