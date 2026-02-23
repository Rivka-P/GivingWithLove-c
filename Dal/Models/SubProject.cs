using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class SubProject
{
    public int SubProjectCode { get; set; }

    public int ProjectCode { get; set; }

    public string SubProjectName { get; set; } = null!;

    public double? EstimatedTime { get; set; }

    public double? EstimatedCost { get; set; }

    public virtual Project ProjectCodeNavigation { get; set; } = null!;

    public virtual ICollection<Volunteering> Volunteerings { get; set; } = new List<Volunteering>();
}
