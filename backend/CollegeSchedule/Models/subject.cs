using System;
using System.Collections.Generic;

namespace CollegeSchedule.Models;

public partial class subject
{
    public int subject_id { get; set; }

    public string name { get; set; } = null!;

    public virtual ICollection<schedule> schedules { get; set; } = new List<schedule>();
}
