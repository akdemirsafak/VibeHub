using Microsoft.AspNetCore.Mvc;
using VibePod.Core.Models.Request.Category;
using VibePod.Core.Services;

namespace VibePod.API.Controllers;

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
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _categoryService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _categoryService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryRequest request)
    {

        return Ok(await _categoryService.CreateAsync(request));

    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateCategoryRequest request)
    {
        return Ok(await _categoryService.UpdateAsync(id, request));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _categoryService.DeleteAsync(id);
        return Ok();
    }

}
