using E_Commerce.Application.DTOs;
using E_Commerce.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.ProductsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto productDto)
        {
            await _service.AddAsync(productDto);
            return CreatedAtAction(nameof(GetProduct), new { id = productDto.Title }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductDto productDto)
        {
            if (await _service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(id, productDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _service.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}