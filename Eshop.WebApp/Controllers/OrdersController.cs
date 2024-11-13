using Eshop.Application.OrderHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly CreateOrderFromCartHandler _createOrderFromCartHandler;
        private readonly GetOrderHandler _getOrderHandler;

        public OrdersController(CreateOrderFromCartHandler createOrderFromCartHandler, GetOrderHandler getOrderHandler)
        {
            _createOrderFromCartHandler = createOrderFromCartHandler;
            _getOrderHandler = getOrderHandler;
        }

        [HttpPut]
        public async Task<ActionResult<OrderDto>> CreateOrderFromCartAsync(CancellationToken ct = default)
        {
            var result = await _createOrderFromCartHandler.CreateOrderAsync(ct);

            if (result.IsFailed)
                return BadRequest(result.Errors[0].Message);
            if (result.Value is null)
                return NotFound();

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllAsync(CancellationToken ct = default)
        {
            var result = await _getOrderHandler.GetAllAsync(ct);

            if (result.IsFailed)
                return BadRequest(result.Errors[0].Message);
            if (result.Value.Count == 0)
                return NotFound();

            return Ok(result.Value);
        }

        [HttpGet("findById")]
        public async Task<ActionResult<OrderDto>> GetByIdAsync([FromQuery] int id, CancellationToken ct = default)
        {
            var result = await _getOrderHandler.GetByIdAsync(id, ct);

            if (result.IsFailed)
                return BadRequest(result.Errors[0].Message);
            if (result.Value is null)
                return NotFound();

            return Ok(result.Value);
        }
    }
}
