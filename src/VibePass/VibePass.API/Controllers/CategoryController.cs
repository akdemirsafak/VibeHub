using Microsoft.AspNetCore.Mvc;

namespace VibePass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("CategoryController");
        }
    }
}
