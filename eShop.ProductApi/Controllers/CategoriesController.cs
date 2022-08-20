using eShop.ProductApi.DTOs;
using eShop.ProductApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShop.ProductApi.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetAll();
            if (categories == null) return NotFound("Categories not found");
            return Ok(categories);
        }
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categories = await _categoryService.GetCategoriesProducts();
            if (categories == null) return NotFound("Categories not found");
            return Ok(categories);
        }
    }
}
