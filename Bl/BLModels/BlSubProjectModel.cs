using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLModels
{
    public class BlSubProjectModel
    {
        public int SubProjectCode { get; set; }

        public int ProjectCode { get; set; }

        public string SubProjectName { get; set; } = null!;

        public double? EstimatedTime { get; set; }

        public double? EstimatedCost { get; set; }

        //public virtual Project ProjectCodeNavigation { get; set; } = null!;

        //public virtual ICollection<Volunteering> Volunteerings { get; set; } = new List<Volunteering>();
    }
}
