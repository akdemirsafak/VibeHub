using Microsoft.AspNetCore.Mvc;
using VibePod.Core.Models.Request;
using VibePod.Core.Services;

namespace VibePod.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanController : ControllerBase
{
    private readonly IPlanService _planService;
    public PlanController(IPlanService planService)
    {
        _planService = planService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _planService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _planService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreatePlanRequest request)
    {

        return Ok(await _planService.CreateAsync(request));

    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdatePlanRequest request)
    {
        return Ok(await _planService.UpdateAsync(id, request));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _planService.DeleteAsync(id);
        return Ok();
    }

}
