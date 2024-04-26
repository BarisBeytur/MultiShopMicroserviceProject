using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryDto categoryDto)
        {
            await _categoryService.CreateAsync(categoryDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryDto categoryDto)
        {
            await _categoryService.UpdateAsync(categoryDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }

    }
}
