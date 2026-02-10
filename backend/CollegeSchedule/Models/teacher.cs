using System;
using System.Collections.Generic;

namespace CollegeSchedule.Models;

public partial class teacher
{
    public int teacher_id { get; set; }

    public string last_name { get; set; } = null!;

    public string first_name { get; set; } = null!;

    public string? middle_name { get; set; }

    public string position { get; set; } = null!;

    public virtual ICollection<schedule> schedules { get; set; } = new List<schedule>();
}
