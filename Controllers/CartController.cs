using ECommerceApi.DTOs;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            var cart = await _service.GetMyCartAsync(userId);
            return Ok(cart);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Add(string userId, [FromBody] CartItemDto dto)
        {
            await _service.AddAsync(userId, dto);
            return Ok("Sepete eklendi");
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> Remove(string cartItemId)
        {
            await _service.RemoveAsync(cartItemId);
            return Ok("Sepetten çıkarıldı");
        }
    }
}
