using Bl.BLApi;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLModels
{
    public class BlVolunteeringModel
    {
        public int VolunteeringCode { get; set; }
        

        public DateOnly DateOfVolunteering { get; set; }

        public int ? VolunteerCode { get; set; }
        public string? VolunteerName { get; set; }

        public int ? PoorManCode { get; set; }
        public string? PoorManName { get; set; }

        public int? MatcherCode { get; set; }
        public string? MatcherName { get; set; }

        public int ? ProjectCode { get; set; }
        public string ? ProjectName { get; set; }

        public int ? SubProjectCode { get; set; }
        public string ? SubProjectName { get; set; }

        //public  BLVolunteerModel? MatcherCodeNavigation { get; set; }

        //public  BlEichudModel? PoorManCodeNavigation { get; set; }

        //public virtual Project ProjectCodeNavigation { get; set; } = null!;

        //public virtual SubProject SubProjectCodeNavigation { get; set; } = null!;

        //public virtual Volunteer? VolunteerCodeNavigation { get; set; }
    }
}
