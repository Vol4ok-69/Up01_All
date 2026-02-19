using CollegeSchedule.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeSchedule.Controllers
{
    [ApiController]
    [Route("api/debug")]
    public class DebugController : ControllerBase
    {
        private readonly CollegeScheduleContext _db;

        public DebugController(CollegeScheduleContext db)
        {
            _db = db;
        }

        [HttpGet("dates")]
        public async Task<IActionResult> GetDates()
        {
            var dates = await _db.schedules
                .Select(s => s.lesson_date)
                .Distinct()
                .OrderBy(d => d)
                .ToListAsync();

            return Ok(dates);
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new
            {
                status = "ok",
                time = DateTime.UtcNow
            });
        }
    }
}
