using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Position
{
    public int positionCode { get; set; }

    public string positionName { get; set; } = null!;

    public virtual ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
}
