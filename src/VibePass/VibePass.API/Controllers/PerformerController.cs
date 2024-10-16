using Microsoft.AspNetCore.Mvc;
using VibePass.Core.Models.Performer;
using VibePass.Core.Service;

namespace VibePass.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PerformerController : ControllerBase
{
    private readonly IPerformerService _performerService;

    public PerformerController(IPerformerService performerService)
    {
        _performerService = performerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _performerService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _performerService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreatePerformerRequest request)
    {
        await _performerService.CreateAsync(request);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _performerService.DeleteByIdAsync(id);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, UpdatePerformerRequest request)
    {
        await _performerService.UpdateAsync(id, request);
        return Ok();
    }

}
