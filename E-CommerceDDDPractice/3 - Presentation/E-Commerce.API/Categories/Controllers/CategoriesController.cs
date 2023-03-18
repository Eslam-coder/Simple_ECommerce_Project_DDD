using E_Commerce.API.Categories.Features.Commands;
using E_Commerce.API.Categories.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Categories.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        //[Authorize]
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCategoryCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
