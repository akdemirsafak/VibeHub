using Microsoft.AspNetCore.Mvc;
using VibePod.Core.Models.Request.Content;
using VibePod.Core.Services;

namespace VibePod.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContentController : ControllerBase
{
    private readonly IContentService _contentService;

    public ContentController(IContentService contentService)
    {
        _contentService = contentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _contentService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _contentService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateContentRequest request)
    {

        return Ok(await _contentService.CreateAsync(request));

    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateContentRequest request)
    {
        return Ok(await _contentService.UpdateAsync(id, request));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _contentService.DeleteAsync(id);
        return Ok();
    }

}
