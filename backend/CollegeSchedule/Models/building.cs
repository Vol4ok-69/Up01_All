using System;
using System.Collections.Generic;

namespace CollegeSchedule.Models;

public partial class building
{
    public int building_id { get; set; }

    public string name { get; set; } = null!;

    public string address { get; set; } = null!;

    public virtual ICollection<classroom> classrooms { get; set; } = new List<classroom>();
}
