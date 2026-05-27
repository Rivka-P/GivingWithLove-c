using Bl.BLApi;
using Bl.BLModels;
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLServices
{
    public class BlProjectService : BlProjectInterface
    {
        private DalProjectInterface Project;
        private BlSubProjectInterface SubProject;
        //private BlVolunteerDomainInterface VolunteerDomain;


    //    Project project = context.Projects
    //.Include(p => p.VolunteerDomains)
    //.FirstOrDefault();

        public BlProjectService(IDal dal, BlSubProjectInterface subProject ,BlVolunteerDomainInterface VolunteerDomains)
        {
            this.Project = dal.Project;
            this.SubProject = subProject;
            //this.VolunteerDomain = VolunteerDomains;
        }


        private Project Convert(BlProjectModel s)
        {
            return new Project()
            {
                ProjectCode = s.ProjectCode,
                ProjectName = s.ProjectName,
                ProjectManagerCode = s.ProjectManagerCode,
                DomainCode = s.DomainCode,
                InverseDomainCodeNavigation = s.InverseDomainCodeNavigation.Select(x => Convert(x)).ToList(),
                SubProjects = s.SubProjects.Select(x => ((BlSubProjectService)SubProject).Convert(x)).ToList(),
                //VolunteerDomains = s.VolunteerDomains
                //.Select(x => volunteerDomainService.Convert(x))
                //.ToList()
                //VolunteerDomains = VolunteerDomainService.Convert(s.VolunteerDomains)
              
                //VolunteerDomain = s.VolunteerDomains.Select(x=>((BlVolunteerDomainService)VolunteerDomains).Convert(x)).ToList()

            };
        }
        private BlProjectModel Convert(Project s)
        {
            BlProjectModel blpm = new BlProjectModel()
            {

                ProjectCode = s.ProjectCode,
                ProjectName = s.ProjectName,
                ProjectManagerCode = s.ProjectManagerCode,
                DomainCode = s.DomainCode ,
                VolunteerDomains= BlVolunteerDomainService.Convert ( s.VolunteerDomain.ToList()),
                InverseDomainCodeNavigation = s.InverseDomainCodeNavigation.Select(x => Convert(x)).ToList(),
                SubProjects =s.SubProjects.Select(x=> ((BlSubProjectService)SubProject).Convert(x)).ToList()
            };
            //if( s.InverseDomainCodeNavigation.Count>0 )
            //{
            //    blpm.InverseDomainCodeNavigation = s.InverseDomainCodeNavigation.Select(x => Convert(x)).ToList();
            //}
            return blpm;
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

        public void Create(BlProjectModel item)
        {
            Project.Create(Convert(item));
        }

        public void Delete(BlProjectModel item)
        {
            Project.Delete(Convert(item));
        }
        public void Update(BlProjectModel item)
        {
            Project.Update(Convert(item));
        }

        public async Task<BlProjectModel> Read(int id)
        {
            try { return Convert(Project.Read(id).Result); }
            catch (ObjectNotFoundException e)
            {
                return null;
            }
        }

        public async Task<List<BlProjectModel>> Read(Func<BlProjectModel, bool> func)
        {
            List<BlProjectModel> list = Convert(Project.Read((Func<Project, bool>)func).Result);
            return list;
        }

        public async Task<List<BlProjectModel>> ReadAll()
        {
            List<BlProjectModel> list = new List<BlProjectModel>();

            Project.ReadAll().Result.ForEach(item => { list.Add(Convert(item)); });

            return list;
        }

       
    }
}
