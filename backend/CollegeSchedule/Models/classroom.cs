using System;
using System.Collections.Generic;

namespace CollegeSchedule.Models;

public partial class classroom
{
    public int classroom_id { get; set; }

    public int building_id { get; set; }

    public string room_number { get; set; } = null!;

    public virtual building building { get; set; } = null!;

    public virtual ICollection<schedule> schedules { get; set; } = new List<schedule>();
}
