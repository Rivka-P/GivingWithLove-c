using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLModels
{
    public class BLVolunteerModel
    {
        public int VolunteerCode { get; set; }

        public int? PositionCode { get; set; }

        public virtual Position? PositionCodeNavigation { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

        public virtual Eichud VolunteerCodeNavigation { get; set; } = null!;

        public virtual ICollection<BlVolunteeringModel> VolunteerDomains { get; set; } = new List<BlVolunteeringModel>();

        public virtual ICollection<Volunteering> VolunteeringMatcherCodeNavigations { get; set; } = new List<Volunteering>();

        public virtual ICollection<Volunteering> VolunteeringVolunteerCodeNavigations { get; set; } = new List<Volunteering>();
    }
}
