using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Volunteer
{
    public int VolunteerCode { get; set; }

    public int? PositionCode { get; set; }

    public virtual Position? PositionCodeNavigation { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual Eichud VolunteerCodeNavigation { get; set; } = null!;

    public virtual ICollection<VolunteerDomain> VolunteerDomains { get; set; } = new List<VolunteerDomain>();

    public virtual ICollection<Volunteering> VolunteeringMatcherCodeNavigations { get; set; } = new List<Volunteering>();

    public virtual ICollection<Volunteering> VolunteeringVolunteerCodeNavigations { get; set; } = new List<Volunteering>();
}
