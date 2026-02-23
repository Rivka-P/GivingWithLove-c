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
    public class BlVolunteerDomainService:BlVolunteerDomainInterface
    {
        DalVolunteerDomainInterface dal;
        public BlVolunteerDomainService(IDal dal)
        {
            this.dal = dal.VolunteerDomains;
        }
        private BlVolunteerDomainModel Convert(VolunteerDomain v)
        {
            return new BlVolunteerDomainModel() {


             VolunteerDomainsCode=v.VolunteerDomainsCode,

             VolunteerCode=v.VolunteerCode,

             ProjectCode=v.ProjectCode
    };
        }
        private List<BlVolunteerDomainModel> Convert(List<VolunteerDomain> v)
        {
            List<BlVolunteerDomainModel> list = new List<BlVolunteerDomainModel>();
            foreach (var item in v)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        private VolunteerDomain Convert(BlVolunteerDomainModel v)
        {
            return new VolunteerDomain() {
                VolunteerDomainsCode = v.VolunteerDomainsCode,

                VolunteerCode = v.VolunteerCode,

                ProjectCode = v.ProjectCode
            };
        }

        public void Create(BlVolunteerDomainModel item)
        {
            dal.Create(Convert(item));
        }

        public void Delete(BlVolunteerDomainModel item)
        {
            dal.Delete(Convert(item));
        }


        public async Task<List<BlVolunteerDomainModel>> ReadAll()
        {
            List<BlVolunteerDomainModel> list = new List<BlVolunteerDomainModel>();

            dal.ReadAll().Result.ForEach(item => { list.Add(Convert(item)); });

            return list;
        }

        public void Update(BlVolunteerDomainModel item)
        {
            dal.Update(Convert(item));

        }
        public async Task<List<BlVolunteerDomainModel>> Read(Func<BlVolunteerDomainModel, bool> func)
        {
            List<BlVolunteerDomainModel> list = Convert(dal.Read((Func<VolunteerDomain, bool>)func).Result);
            return list;

        }

        public async Task<BlVolunteerDomainModel> Read(int vl)
        {
           return Convert(dal.Read(vl).Result);
        }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
    }
}

