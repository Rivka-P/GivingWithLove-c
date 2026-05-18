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
    public class BlProjectService : BlProjectInterface
    {
        private DalProjectInterface Project;
        public BlProjectService(IDal dal)
        {
            this.Project = dal.Project;
        }

        private Project Convert(BlProjectModel s)
        {
            return new Project()
            {
                ProjectCode = s.ProjectCode,
                ProjectName = s.ProjectName,
                ProjectManagerCode = s.ProjectManagerCode,
                DomainCode = s.DomainCode
            };
        }

        private BlProjectModel Convert(Project s)
        {
            return new BlProjectModel()
            {
                ProjectCode = s.ProjectCode,
                ProjectName = s.ProjectName,
                ProjectManagerCode = s.ProjectManagerCode,
                DomainCode = s.DomainCode
            };
        }

        private List<BlProjectModel> Convert(List<Project> c)
        {
            List<BlProjectModel> list = new List<BlProjectModel>();
            foreach (var item in c)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public async Task CreateAsync(BlProjectModel item)
        {
            await Project.CreateAsync(Convert(item));
        }

        public async Task DeleteAsync(BlProjectModel item)
        {
            await Project.DeleteAsync(Convert(item));
        }

        public async Task UpdateAsync(BlProjectModel item)
        {
            await Project.UpdateAsync(Convert(item));
        }

        public async Task<BlProjectModel> ReadAsync(int id)
        {
            try
            {
                var data = await Project.ReadAsync(id);
                return Convert(data);
            }
            catch (ObjectNotFoundException)
            {
                return null;
            }
        }

        public async Task<List<BlProjectModel>> ReadAsync(Func<BlProjectModel, bool> func)
        {
            var allData = await Project.ReadAllAsync();
            return allData.Select(Convert).Where(func).ToList();
        }

        public async Task<List<BlProjectModel>> ReadAllAsync()
        {
            var allData = await Project.ReadAllAsync();
            return allData.Select(Convert).ToList();
        }
    }
}