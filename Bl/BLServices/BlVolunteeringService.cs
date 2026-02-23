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
    public class BlVolunteeringService:BlVolunteeringInterface
    {
        DalVolunteeringInterface dal;
        public BlVolunteeringService(IDal dal)
        {
            this.dal = dal.Volunteerings;
        }
        private BLModels.BlVolunteeringModel Convert(Volunteering v)
        {
            return new BLModels.BlVolunteeringModel() {
                DateOfVolunteering = v.DateOfVolunteering,
                MatcherCode = v.MatcherCode,
                VolunteerCode = v.VolunteerCode,
                PoorManCode = v.PoorManCode,
                ProjectCode = v.ProjectCode,
                SubProjectCode = v.SubProjectCode
            };
        }
        private List<BLModels.BlVolunteeringModel> Convert(List<Volunteering> v)
        {
            List<BLModels.BlVolunteeringModel> list = new List<BLModels.BlVolunteeringModel>();
            foreach (var item in v)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        private Volunteering Convert(BLModels.BlVolunteeringModel v)
        {
            return new Volunteering() {
                DateOfVolunteering = v.DateOfVolunteering,
                MatcherCode = v.MatcherCode ,
                VolunteerCode = v.VolunteerCode,
                PoorManCode=v.PoorManCode,
                ProjectCode=v.ProjectCode,
                SubProjectCode=v.SubProjectCode
                  };
        }

        public void Create(BLModels.BlVolunteeringModel item)
        {
            dal.Create(Convert(item));
        }

        public void Delete(BLModels.BlVolunteeringModel item)
        {
            dal.Delete(Convert(item));
        }


        public async Task<List<BLModels.BlVolunteeringModel>> ReadAll()
        {
            List<BLModels.BlVolunteeringModel> list = new List<BLModels.BlVolunteeringModel>();

            dal.ReadAll().Result.ForEach(item => { list.Add(Convert(item)); });

            return list;
        }

        public void Update(BLModels.BlVolunteeringModel item)
        {
            dal.Update(Convert(item));

        }
        public async Task<List<BLModels.BlVolunteeringModel>> Read(Func<BLModels.BlVolunteeringModel, bool> func)
        {
            List<BLModels.BlVolunteeringModel> list = Convert(dal.Read((Func<Volunteering, bool>)func).Result);
            return list;

        }

        public async Task<BLModels.BlVolunteeringModel> Read(int id)
        {
           //BLVolunteeringModel model=Convert(dal.ReadAll().Result.Find(v=>v.VolunteerCode==id));
           return Convert(dal.Read(id).Result);
        }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
    }
}

