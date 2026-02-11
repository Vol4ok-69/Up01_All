using CollegeSchedule.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSchedule.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _service;

        public ScheduleController(IScheduleService service)
        {
            _service = service;
        }

        [HttpGet("{groupName}")]
        public async Task<IActionResult> GetSchedule(
            string groupName,
            [FromQuery] DateTime start,
            [FromQuery] DateTime end)
        {
            var result = await _service
                .GetScheduleForGroup(groupName, start, end);

            return Ok(result);
        }
    }
}
