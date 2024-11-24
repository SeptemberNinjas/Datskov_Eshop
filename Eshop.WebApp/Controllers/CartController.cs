using Eshop.Application.CartHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly GetCartHandler _getCartHandler;
        private readonly AddItemToCartHandler _addItemToCartHandler;
        private readonly ClearCartHandler _clearCartHandler;

        public CartController(GetCartHandler getCartHandler, AddItemToCartHandler addItemToCartHandler, ClearCartHandler clearCartHandler) {
            _getCartHandler = getCartHandler;
            _addItemToCartHandler = addItemToCartHandler;
            _clearCartHandler = clearCartHandler;
        }

        [HttpGet]
        public async Task<ActionResult<CartDto>> GetAsync(CancellationToken ct = default)
        {
            var result = await _getCartHandler.GetAsync(ct);

            if (result.IsFailed)
                return BadRequest(result.ToString());
            if (result.Value is null)
                return NotFound();

            return Ok(result.Value);
        }
        [HttpPost("AddItem")]
        public async Task<ActionResult> AddItemAsync([FromQuery] int saleItemId, [FromQuery] uint count = 1, CancellationToken ct = default)
        {
            var result = await _addItemToCartHandler.AddToCartAsync(saleItemId, count, ct);
            if (result.IsFailed)
                return BadRequest(result.Errors[0].Message);

            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> ClearAsync(CancellationToken ct = default)
        {
            var result = await _clearCartHandler.ClearCartAsync(ct);
            if (result.IsFailed)
                return BadRequest(result.Errors[0].Message);

            return Ok();
        }
    }
}
