using Eshop.Application.SaleItemHandlers;
using Eshop.Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eshop.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly GetSaleItemHandler _handler;

        public CatalogController(GetSaleItemHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<SaleItemDto>>> GetProductsAsync(CancellationToken ct = default)
        {
            var result = await _handler.GetAllAsync(SaleItemType.Product, ct);
            if (result.IsFailed)
                return BadRequest(result.Errors[0].Message);
            if (!result.Value.Any())
                return NotFound();

            return Ok(result.Value);
        }

        [HttpGet("services")]
        public async Task<ActionResult<IEnumerable<SaleItemDto>>> GetServicesAsync(CancellationToken ct = default)
        {
            var result = await _handler.GetAllAsync(SaleItemType.Service, ct);
            if (result.IsFailed)
                return BadRequest(result.Errors[0].Message);
            if (!result.Value.Any())
                return NotFound();

            return Ok(result.Value);
        }

        [HttpGet("findById")]
        public async Task<ActionResult<SaleItemDto>> GetByIdAsync([FromQuery] int id, CancellationToken ct = default)
        {
            var result = await _handler.GetByIdAsync(id, ct);
            if (result.IsFailed)
                return BadRequest(result.Errors[0].Message);
            if (result.Value is null)
                return NotFound();

            return Ok(result.Value);
        }
    }
}
