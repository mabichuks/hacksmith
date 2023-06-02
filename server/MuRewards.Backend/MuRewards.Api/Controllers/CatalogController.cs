using Microsoft.AspNetCore.Mvc;
using MuRewards.Core.Interfaces;
using MuRewards.Core.Models;

namespace MuRewards.Api.Controllers
{
    [ApiController]
    [Route("api/v1/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogManager _catalogManager;

        public CatalogController(ICatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCatalog()
        {
            var result = await _catalogManager.GetCatalog();
            return Ok(result);
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CartModel cart)
        {
            var result = await _catalogManager.Checkout(cart);
            return Ok(result);
        }
    }
}
