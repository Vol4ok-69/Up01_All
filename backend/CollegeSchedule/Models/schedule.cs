using System;
using System.Collections.Generic;

namespace CollegeSchedule.Models;

public partial class schedule
{
    public int schedule_id { get; set; }

    public DateOnly lesson_date { get; set; }

    public int weekday_id { get; set; }

    public int lesson_time_id { get; set; }

    public int group_id { get; set; }

    public int subject_id { get; set; }

    public int teacher_id { get; set; }

    public int classroom_id { get; set; }

    public virtual classroom classroom { get; set; } = null!;

    public virtual student_group group { get; set; } = null!;

    public virtual lesson_time lesson_time { get; set; } = null!;

    public virtual subject subject { get; set; } = null!;

    public virtual teacher teacher { get; set; } = null!;

    public virtual weekday weekday { get; set; } = null!;
}
