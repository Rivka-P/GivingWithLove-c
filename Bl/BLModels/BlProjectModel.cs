using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLModels
{
    public class BlProjectModel
    {
        public int ProjectCode { get; set; }

        public string ProjectName { get; set; } = null!;

        public int? ProjectManagerCode { get; set; }

        public int DomainCode { get; set; }

        //public virtual Project DomainCodeNavigation { get; set; } = null!;

        //public virtual ICollection<Project> InverseDomainCodeNavigation { get; set; } = new List<Project>();

        //public virtual Volunteer? ProjectManagerCodeNavigation { get; set; }

        //public virtual ICollection<SubProject> SubProjects { get; set; } = new List<SubProject>();

        //public virtual ICollection<VolunteerDomain> VolunteerDomains { get; set; } = new List<VolunteerDomain>();

        //public virtual ICollection<Volunteering> Volunteerings { get; set; } = new List<Volunteering>();
    }
}
