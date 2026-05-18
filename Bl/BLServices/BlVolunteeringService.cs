using Bl.BLApi;
using Bl.BLModels;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bl.BLServices
{
    public class BlVolunteeringService : BlVolunteeringInterface
    {
        private readonly DalVolunteeringInterface dal;
        private readonly BlVolunteerInterface volunteerInterface;
        private readonly BlProjectInterface projectInterface;
        private readonly BlSubProjectInterface subProjectInterface;

        public BlVolunteeringService(
            IDal dal,
            BlVolunteerInterface volunteerInterface,
            BlProjectInterface projectInterface,
            BlSubProjectInterface subProjectInterface)
        {
            this.dal = dal.Volunteerings;
            this.volunteerInterface = volunteerInterface;
            this.projectInterface = projectInterface;
            this.subProjectInterface = subProjectInterface;
        }

        // =========================
        // Convert (SAFE - NO PARALLEL)
        // =========================
        private async Task<BlVolunteeringModel> Convert(Volunteering v)
        {
            var blV = new BlVolunteeringModel
            {
                VolunteeringCode = v.VolunteeringCode,
                DateOfVolunteering = v.DateOfVolunteering,
                MatcherCode = v.MatcherCode,
                VolunteerCode = v.VolunteerCode,
                PoorManCode = v.PoorManCode,
                ProjectCode = v.ProjectCode,
                SubProjectCode = v.SubProjectCode
            };

            if (v.MatcherCode.HasValue)
            {
                var matcher = await volunteerInterface.ReadAsync(v.MatcherCode.Value);
                if (matcher != null)
                    blV.MatcherName = $"{matcher.VolunteerCodeNavigation.FirstName} {matcher.VolunteerCodeNavigation.FamilyName}";
            }

            if (v.VolunteerCode.HasValue)
            {
                var volunteer = await volunteerInterface.ReadAsync(v.VolunteerCode.Value);
                if (volunteer != null)
                    blV.VolunteerName = $"{volunteer.VolunteerCodeNavigation.FirstName} {volunteer.VolunteerCodeNavigation.FamilyName}";
            }

            if (v.PoorManCode.HasValue)
            {
                var poorMan = await volunteerInterface.ReadAsync(v.PoorManCode.Value);
                if (poorMan != null)
                    blV.PoorManName = $"{poorMan.VolunteerCodeNavigation.FirstName} {poorMan.VolunteerCodeNavigation.FamilyName}";
            }

            if (v.ProjectCode.HasValue)
            {
                var project = await projectInterface.ReadAsync(v.ProjectCode.Value);
                if (project != null)
                    blV.ProjectName = project.ProjectName;
            }

            if (v.SubProjectCode.HasValue)
            {
                var subProject = await subProjectInterface.ReadAsync(v.SubProjectCode.Value);
                if (subProject != null)
                    blV.SubProjectName = subProject.SubProjectName;
            }

            return blV;
        }

        private Volunteering Convert(BlVolunteeringModel v)
        {
            return new Volunteering
            {
                VolunteeringCode = v.VolunteeringCode,
                DateOfVolunteering = v.DateOfVolunteering,
                MatcherCode = v.MatcherCode,
                VolunteerCode = v.VolunteerCode,
                PoorManCode = v.PoorManCode,
                ProjectCode = v.ProjectCode,
                SubProjectCode = v.SubProjectCode
            };
        }

        // =========================
        // Convert List (SAFE LOOP)
        // =========================
        private async Task<List<BlVolunteeringModel>> ConvertListAsync(List<Volunteering> list)
        {
            var result = new List<BlVolunteeringModel>();

            foreach (var item in list)
            {
                result.Add(await Convert(item));
            }

            return result;
        }

        // =========================
        // CRUD
        // =========================
        public async Task CreateAsync(BlVolunteeringModel item)
            => await dal.CreateAsync(Convert(item));

        public async Task DeleteAsync(BlVolunteeringModel item)
            => await dal.DeleteAsync(Convert(item));

        public async Task UpdateAsync(BlVolunteeringModel item)
            => await dal.UpdateAsync(Convert(item));

        public async Task<BlVolunteeringModel> ReadAsync(int id)
        {
            var v = await dal.ReadAsync(id);
            return await Convert(v);
        }

        public async Task<List<BlVolunteeringModel>> ReadAllAsync()
        {
            var list = await dal.ReadAllAsync();
            return await ConvertListAsync(list);
        }

        public async Task<List<BlVolunteeringModel>> ReadAsync(Func<BlVolunteeringModel, bool> func)
        {
            var raw = await dal.ReadAsync(v => true);
            var converted = await ConvertListAsync(raw);
            return converted.Where(func).ToList();
        }
    }
}