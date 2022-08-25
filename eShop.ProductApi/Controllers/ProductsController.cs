using eShop.ProductApi.DTOs;
using eShop.ProductApi.Services;
using eShop.ProductApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetAll();
            if (products == null) return NotFound("Products not found");
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var category = await _productService.GetById(id);
            if (category == null) return NotFound("Category not found");
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest("Invalid Data");

            await _productService.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id) return BadRequest();
            if (productDTO == null) return BadRequest("Invalid Data");

            await _productService.Update(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productDTO = await _productService.GetById(id);

            if (productDTO == null) return NotFound("Category not found");

            await _productService.Remove(id);

            return Ok(productDTO);
        }
    }
}
