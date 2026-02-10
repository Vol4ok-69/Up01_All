using Microsoft.AspNetCore.Mvc;

namespace CollegeSchedule.Controllers;

[ApiController]
[Route("api/ping")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok(new
        {
            status = "ok",
            time = DateTime.UtcNow
        });
    }
}
