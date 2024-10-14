using Microsoft.AspNetCore.Mvc;
using VibePass.Core.Models.Eventy;
using VibePass.Core.Service;

namespace VibePass.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventyService _eventService;

    public EventController(IEventyService eventService)
    {
        _eventService = eventService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _eventService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _eventService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEventyRequest request)
    {
        await _eventService.CreateAsync(request);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] UpdateEventyRequest request)
    {
        await _eventService.UpdateAsync(id, request);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _eventService.DeleteByIdAsync(id);
        return Ok();
    }
}
