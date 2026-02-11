using CollegeSchedule.Models;

namespace CollegeSchedule.DTO
{
    public class LessonDto
    {
        public int LessonNumber { get; set; }

        public string Time { get; set; } = null!;

        public Dictionary<lesson_group_part, LessonPartDto?> GroupParts { get; set; }
            = new();
    }
}
