using Microsoft.AspNetCore.Mvc;
using VibePod.Core.Models.Request.Vibe;
using VibePod.Core.Services;

namespace VibePod.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VibeController : ControllerBase
{

    private readonly IVibeService _vibeService;

    public VibeController(IVibeService vibeService)
    {
        _vibeService = vibeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _vibeService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _vibeService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateVibeRequest request)
    {

        return Ok(await _vibeService.CreateAsync(request));

    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateVibeRequest request)
    {
        return Ok(await _vibeService.UpdateAsync(id, request));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _vibeService.DeleteAsync(id);
        return Ok();
    }

}
