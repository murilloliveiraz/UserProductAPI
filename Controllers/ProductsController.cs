using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserProductAPI.Data.DTOS;
using UserProductAPI.Services;

namespace UserProductAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        [ProducesResponseType(typeof(ProductDTO), 201)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO)
        {
            var product = await _productService.CreateProduct(productDTO);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDTO>), 200)]
        public Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return _productService.ListProducts();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDTO), 200)]
        public Task<ProductDTO> GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDTO)
        {
            await _productService.UpdateProduct(id, productDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
