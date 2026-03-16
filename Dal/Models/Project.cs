using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dal.Models;

public partial class Project
{
     public int ProjectCode { get; set; }
    public string ProjectName { get; set; }
    public  int ? ProjectManagerCode { get; set; }
    public int? DomainCode { get; set; }

    public virtual Project DomainCodeNavigation { get; set; } = null!;

    public virtual ICollection<Project> InverseDomainCodeNavigation { get; set; } = new List<Project>();

    public virtual Volunteer? ProjectManagerCodeNavigation { get; set; }

    public virtual ICollection<SubProject> SubProjects { get; set; } = new List<SubProject>();

    public virtual ICollection<VolunteerDomain> VolunteerDomains { get; set; } = new List<VolunteerDomain>();

    public virtual ICollection<Volunteering> Volunteerings { get; set; } = new List<Volunteering>();
}
