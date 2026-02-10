using System;
using System.Collections.Generic;

namespace CollegeSchedule.Models;

public partial class specialty
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public virtual ICollection<student_group> student_groups { get; set; } = new List<student_group>();
}
