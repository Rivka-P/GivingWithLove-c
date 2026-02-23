using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface DalEichudInterface : ICrud<Eichud>
    {
        object Read(global::Bl.BLModels.BlEichudModel item);
    }
}
