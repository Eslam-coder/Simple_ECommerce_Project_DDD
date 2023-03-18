using E_Commerce.API.Orders.Features.Commands;
using E_Commerce.API.Orders.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Orders.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var query = new GetOrderByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        //[Authorize]
        [HttpPut("edit")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[Authorize]
        [HttpDelete("remove-order")]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
