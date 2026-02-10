using System;
using System.Collections.Generic;

namespace CollegeSchedule.Models;

public partial class weekday
{
    public int weekday_id { get; set; }

    public string name { get; set; } = null!;

    public virtual ICollection<schedule> schedules { get; set; } = new List<schedule>();
}
