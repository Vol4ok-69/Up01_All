using CollegeSchedule.Data;
using CollegeSchedule.DTO;
using CollegeSchedule.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSchedule.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly CollegeScheduleContext _db;

        public ScheduleService(CollegeScheduleContext db)
        {
            _db = db;
        }

        public async Task<List<ScheduleByDateDto>> GetScheduleForGroup(
            string groupName,
            DateTime startDate,
            DateTime endDate)
        {
            var group = await _db.student_groups
                .FirstOrDefaultAsync(g => g.group_name == groupName);

            if (group == null)
                throw new Exception("Группа не найдена");

            var start = DateOnly.FromDateTime(startDate);
            var end = DateOnly.FromDateTime(endDate);

            var schedules = await _db.schedules
                .Where(s => s.group_id == group.group_id &&
                            s.lesson_date >= start &&
                            s.lesson_date <= end)
                .Include(s => s.lesson_time)
                .Include(s => s.subject)
                .Include(s => s.teacher)
                .Include(s => s.classroom)
                    .ThenInclude(c => c.building)
                .Include(s => s.weekday)
                .OrderBy(s => s.lesson_date)
                .ThenBy(s => s.lesson_time.lesson_number)
                .ToListAsync();

            var result = schedules
                .GroupBy(s => s.lesson_date)
                .Select(dayGroup => new ScheduleByDateDto
                {
                    LessonDate = dayGroup.Key.ToDateTime(TimeOnly.MinValue),
                    Weekday = dayGroup.First().weekday.name,
                    Lessons = dayGroup.Select(s => new LessonDto
                    {
                        LessonNumber = s.lesson_time.lesson_number,
                        Time = $"{s.lesson_time.time_start:HH:mm}-{s.lesson_time.time_end:HH:mm}",
                        GroupParts = new Dictionary<lesson_group_part, LessonPartDto?>
                        {
                            {
                                lesson_group_part.FULL,
                                new LessonPartDto
                                {
                                    Subject = s.subject.name,
                                    Teacher = $"{s.teacher.last_name} {s.teacher.first_name} {s.teacher.middle_name}",
                                    TeacherPosition = s.teacher.position,
                                    Classroom = s.classroom.room_number,
                                    Building = s.classroom.building.name,
                                    Address = s.classroom.building.address
                                }
                            }
                        }
                    }).ToList()
                })
                .ToList();

            return result;
        }
    }
}
