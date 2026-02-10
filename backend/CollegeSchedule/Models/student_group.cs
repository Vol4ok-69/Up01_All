using System;
using System.Collections.Generic;

namespace CollegeSchedule.Models;

public partial class student_group
{
    public int group_id { get; set; }

    public string group_name { get; set; } = null!;

    public int course { get; set; }

    public int specialty_id { get; set; }

    public virtual ICollection<schedule> schedules { get; set; } = new List<schedule>();

    public virtual specialty specialty { get; set; } = null!;
}
