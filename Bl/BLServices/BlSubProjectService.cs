using Bl.BLApi;
using Bl.BLModels;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLServices
{
    public class BlSubProjectService : BlSubProjectInterface
    {
        private DalSubProjectInterfase SubProject;
        public BlSubProjectService(IDal dal)
        {
            this.SubProject = (DalSubProjectInterfase?)dal.SubProject;
        }

        private SubProject Convert(BlSubProjectModel s)
        {
            return new SubProject() {
                SubProjectCode = s.SubProjectCode,
                ProjectCode = s.ProjectCode,
                SubProjectName = s.SubProjectName,
                EstimatedTime = s.EstimatedTime,
                EstimatedCost = s.EstimatedCost
            };
        }
        private BlSubProjectModel Convert(SubProject s)
        {
            return new BlSubProjectModel() {
                SubProjectCode = s.SubProjectCode,
                ProjectCode = s.ProjectCode,
                SubProjectName = s.SubProjectName,
                EstimatedTime = s.EstimatedTime,
                EstimatedCost = s.EstimatedCost
            };
        }
        private List<BlSubProjectModel> Convert(List<SubProject> c)
        {
            List<BlSubProjectModel> list = new List<BlSubProjectModel>();
            foreach (var item in c)
            {
                list.Add(Convert(item));
            }
            return list;
        }


        public void Delete(BlSubProjectModel item)
        {
            throw new NotImplementedException();
        }

        public void Create(BlSubProjectModel item)
        {
            SubProject.Create(Convert(item));
        }

        public void Update(BlSubProjectModel item)
        {
            throw new NotImplementedException();
        }

        public async Task<BlSubProjectModel> Read(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BlSubProjectModel>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BlSubProjectModel>> Read(Func<BlSubProjectModel, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
