using Bl.BLApi;
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
            return c.Select(Convert).ToList();
        }

        public async Task DeleteAsync(BlSubProjectModel item)
        {
            SubProject.DeleteAsync(Convert(item));
        }

        public async Task CreateAsync(BlSubProjectModel item)
        {
            SubProject.CreateAsync(Convert(item));
        }

        public async Task UpdateAsync(BlSubProjectModel item)
        {
            SubProject.UpdateAsync(Convert(item));
        }

        public async Task<BlSubProjectModel> ReadAsync(int id)
        {
            try
            {
                var data = await SubProject.ReadAsync(id);
                return Convert(data);
            }
            catch (ObjectNotFoundException)
            {
                return null;
            }
        }

        public async Task<List<BlSubProjectModel>> ReadAllAsync()
        {
            var data = await SubProject.ReadAllAsync();
            return Convert(data);
        }

        public async Task<List<BlSubProjectModel>> ReadAsync(Func<BlSubProjectModel, bool> func)
        {
            var data = await SubProject.ReadAllAsync(); // במקום להשתמש ב-Result
            return Convert(data).Where(func).ToList();
        }
    }
}