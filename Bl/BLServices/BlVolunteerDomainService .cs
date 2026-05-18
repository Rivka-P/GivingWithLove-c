using Bl.BLModels;
using Dal.Api;
using Dal.Models;
using Bl.BLApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bl.BLServices
{
    public class BlVolunteerDomainService : BlVolunteerDomainInterface
    {
        private readonly DalVolunteerDomainInterface dal;

        public BlVolunteerDomainService(IDal dal)
        {
            this.dal = dal.VolunteerDomains;
        }

        public BlVolunteerDomainModel Convert(VolunteerDomain v) => new BlVolunteerDomainModel
        {
            VolunteerDomainsCode = v.VolunteerDomainsCode,
            VolunteerCode = v.VolunteerCode,
            ProjectCode = v.ProjectCode
        };

        public VolunteerDomain Convert(BlVolunteerDomainModel v) => new VolunteerDomain
        {
            VolunteerDomainsCode = v.VolunteerDomainsCode,
            VolunteerCode = v.VolunteerCode,
            ProjectCode = v.ProjectCode
        };

        public List<BlVolunteerDomainModel> Convert(List<VolunteerDomain> list) =>
            list.Select(Convert).ToList();

        public async Task CreateAsync(BlVolunteerDomainModel item) => dal.CreateAsync(Convert(item));

        public async Task DeleteAsync(BlVolunteerDomainModel item) => dal.DeleteAsync(Convert(item));

        public async Task UpdateAsync(BlVolunteerDomainModel item) => dal.UpdateAsync(Convert(item));

        public async Task<BlVolunteerDomainModel> ReadAsync(int id)
        {
            var entity = await dal.ReadAsync(id);
            return entity == null ? null : Convert(entity);
        }

        public async Task<List<BlVolunteerDomainModel>> ReadAllAsync()
        {
            var entities = await dal.ReadAllAsync();
            return Convert(entities);
        }

        public async Task<List<BlVolunteerDomainModel>> ReadAsync(Func<BlVolunteerDomainModel, bool> func)
        {
            var entities = await dal.ReadAsync(v => func(Convert(v)));
            return Convert(entities);
        }
    }
}