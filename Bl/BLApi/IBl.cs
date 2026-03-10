using Dal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLApi
{
    public interface IBl
    {
        public BlVolunteerInterface Volunteer { get; }
        public BlVolunteeringInterface Volunteerings { get; }
        public BlVolunteerDomainInterface VolunteerDomains { get; }
        public BlEichudInterface Eichud { get; }
        public BlSubProjectInterface SubProject { get; }
        public BlProjectInterface Project { get; }
        public BlPositionInterface Position { get; }

    }
}
