using System;
using System.Collections.Generic;

namespace CollegeSchedule.Models;

public partial class lesson_time
{
    public int lesson_time_id { get; set; }

    public int lesson_number { get; set; }

    public TimeOnly time_start { get; set; }

    public TimeOnly time_end { get; set; }

    public virtual ICollection<schedule> schedules { get; set; } = new List<schedule>();
}
