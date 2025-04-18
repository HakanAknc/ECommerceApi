using ECommerceApi.DTOs;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) =>
            Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Ürün oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ProductDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok("Ürün güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok("Ürün silindi");
        }
    }
}
