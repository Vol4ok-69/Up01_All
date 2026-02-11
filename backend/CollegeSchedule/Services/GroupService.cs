using CollegeSchedule.Data;
using CollegeSchedule.DTO;
using Microsoft.EntityFrameworkCore;

namespace CollegeSchedule.Services
{
    public class GroupService : IGroupService
    {
        private readonly CollegeScheduleContext _db;

        public GroupService(CollegeScheduleContext db)
        {
            _db = db;
        }

        public async Task<List<GroupDto>> GetAllGroups()
        {
            return await _db.student_groups
                .OrderBy(g => g.group_name)
                .Select(g => new GroupDto
                {
                    GroupName = g.group_name
                })
                .ToListAsync();
        }
    }
}
