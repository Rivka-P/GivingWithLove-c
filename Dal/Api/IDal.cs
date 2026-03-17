using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDal
    {
        public DalVolunteerInterface Volunteer { get; }
        public DalVolunteeringInterface Volunteerings { get; }
        public DalEichudInterface Eichud { get; }
        public DalVolunteerDomainInterface VolunteerDomains { get; }
        public DalSubProjectInterface SubProject { get; }
        public DalPositionInterface Position { get; }

        //public DalProjectInterface Project { get; }

        public DalProjectInterface Project { get; }

    }
}
