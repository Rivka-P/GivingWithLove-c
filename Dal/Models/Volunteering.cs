using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Volunteering
{
    public int VolunteeringCode { get; set; }

    public DateOnly DateOfVolunteering { get; set; }

    public int? VolunteerCode { get; set; }

    public int? PoorManCode { get; set; }

    public int? MatcherCode { get; set; }

    public int ProjectCode { get; set; }

    public int SubProjectCode { get; set; }

    public virtual Volunteer? MatcherCodeNavigation { get; set; }

    public virtual Eichud? PoorManCodeNavigation { get; set; }

    public virtual Project ProjectCodeNavigation { get; set; } = null!;

    public virtual SubProject SubProjectCodeNavigation { get; set; } = null!;

    public virtual Volunteer? VolunteerCodeNavigation { get; set; }
}
