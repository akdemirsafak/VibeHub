using Microsoft.AspNetCore.Mvc;
using VibePass.Core.Models.Category;
using VibePass.Core.Service;

namespace VibePass.API.Controllers
{
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
            return Ok(await _categoryService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryRequest request)
        {
            await _categoryService.CreateAsync(request);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateCategoryRequest request)
        {
            await _categoryService.UpdateAsync(id, request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _categoryService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
