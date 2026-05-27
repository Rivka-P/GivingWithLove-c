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

        public int? DomainCode { get; set; }

        //public virtual Project DomainCodeNavigation { get; set; } = null!;

        public List<BlProjectModel> InverseDomainCodeNavigation { get; set; } = new List<BlProjectModel>();

        //public virtual Volunteer? ProjectManagerCodeNavigation { get; set; }

        public  List<BlSubProjectModel> SubProjects { get; set; } = new List<BlSubProjectModel>();

        public List<BlVolunteerDomainModel> VolunteerDomains { get; set; } = new List<BlVolunteerDomainModel>();

        //public virtual ICollection<Volunteering> Volunteerings { get; set; } = new List<Volunteering>();
    }
}
