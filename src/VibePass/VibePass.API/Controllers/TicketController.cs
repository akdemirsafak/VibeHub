using Microsoft.AspNetCore.Mvc;
using VibePass.Core.Models.Ticket;
using VibePass.Core.Service;

namespace VibePass.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _ticketService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _ticketService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTicketRequest request)
    {
        await _ticketService.CreateAsync(request);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] UpdateTicketRequest request)
    {
        await _ticketService.UpdateAsync(id, request);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _ticketService.DeleteByIdAsync(id);
        return Ok();
    }
}