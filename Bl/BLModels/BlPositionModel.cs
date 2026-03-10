using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLModels
{
    public class BlPositionModel
    {
        public int PositionCode { get; set; }

        public string PositionName { get; set; } = null!;

        //public virtual ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
    }
}
