<<<<<<< HEAD
﻿using Bl.BLApi;
using Bl.BLModels;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bl.BLServices
{
    public class BlSubProjectService : BlSubProjectInterface
    {
        private DalSubProjectInterface SubProject;

        public BlSubProjectService(IDal dal)
        {
            this.SubProject = dal.SubProject;
        }

        private SubProject Convert(BlSubProjectModel s)
        {
            if (s == null) return null;

            return new SubProject()
            {
                SubProjectCode = s.SubProjectCode,
                ProjectCode = s.ProjectCode,
                SubProjectName = s.SubProjectName,
                EstimatedTime = s.EstimatedTime,
                EstimatedCost = s.EstimatedCost
            };
        }

        private BlSubProjectModel Convert(SubProject s)
        {
            if (s == null) return null;

            return new BlSubProjectModel()
            {
                SubProjectCode = s.SubProjectCode,
                ProjectCode = s.ProjectCode,
                SubProjectName = s.SubProjectName,
                EstimatedTime = s.EstimatedTime,
                EstimatedCost = s.EstimatedCost
            };
        }

        private List<BlSubProjectModel> Convert(List<SubProject> c)
        {
            if (c == null) return new List<BlSubProjectModel>();

            List<BlSubProjectModel> list = new List<BlSubProjectModel>();
            foreach (var item in c)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public void Create(BlSubProjectModel item)
        {
            SubProject.Create(Convert(item));
        }

        public void Delete(BlSubProjectModel item)
        {
            SubProject.Delete(Convert(item));
        }

        public void Update(BlSubProjectModel item)
        {
            SubProject.Update(Convert(item));
        }

        public async Task<BlSubProjectModel> Read(int id)
        {
            var result = await SubProject.Read(id);
            return Convert(result);
        }

        public async Task<List<BlSubProjectModel>> ReadAll()
        {
            var list = await SubProject.ReadAll();
            return Convert(list);
        }

        public async Task<List<BlSubProjectModel>> Read(Func<BlSubProjectModel, bool> func)
        {
            var list = await SubProject.ReadAll();
            var blList = Convert(list);
            return blList.Where(func).ToList();
        }
    }
}
=======
﻿using Bl.BLApi;
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
        private DalSubProjectInterface SubProject;
        public BlSubProjectService(IDal dal)
        {
            this.SubProject = dal.SubProject;
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
            SubProject.Delete(Convert(item));
        }

        public void Create(BlSubProjectModel item)
        {
            SubProject.Create(Convert(item));
        }

        public void Update(BlSubProjectModel item)
        {
            SubProject.Update(Convert(item));
        }

        public async Task<BlSubProjectModel> Read(int id)
        {
            try { return Convert(SubProject.Read(id).Result); }
            catch (ObjectNotFoundException e)
            {
                return null;
            }
        }

        public async Task<List<BlSubProjectModel>> ReadAll()
        {
            List<BlSubProjectModel> list = new List<BlSubProjectModel>();

            SubProject.ReadAll().Result.ForEach(item => { list.Add(Convert(item)); });

            return list;
        }

        public async Task<List<BlSubProjectModel>> Read(Func<BlSubProjectModel, bool> func)
        {
            List<BlSubProjectModel> list = Convert(SubProject.Read((Func<SubProject, bool>)func).Result);
            return list;
        }
    }
}
>>>>>>> refs/remotes/origin/main
