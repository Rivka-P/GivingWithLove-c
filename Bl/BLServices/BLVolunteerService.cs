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
    public class BLVolunteerService : BlVolunteerInterface
    {
        DalSubProjectInterfase Volunteer;
        public BLVolunteerService(IDal dal)
        {
            this.Volunteer = dal.Volunteer;
        }
        private Volunteer Convert(BLVolunteerModel v)
        {
            return new Volunteer() { VolunteerCode = v.VolunteerCode, PositionCode = v.PositionCode };
        }
        private BLVolunteerModel Convert(Volunteer v)
        {
            return new BLVolunteerModel() { VolunteerCode = v.VolunteerCode, PositionCode = v.PositionCode };
        }
        private List<BLVolunteerModel> Convert(List<Volunteer> c)
        {
            List<BLVolunteerModel> list = new List<BLVolunteerModel>();
            foreach (var item in c)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public void Create(BLVolunteerModel item)
        {
            Volunteer.Create(Convert(item));
        }

        public void Delete(BLVolunteerModel item)
        {
            Volunteer.Delete(Convert(item));
        }

        public async Task<BLVolunteerModel> Read(int id)
        {
            //return Convert(Volunteer.Read(Convert(item)).Result);
            //return Volunteer.Read.Result(Convert(item));
            throw new NotImplementedException();
        }

        public async Task<List<BLVolunteerModel>> Read(Func<BLVolunteerModel, bool> func)
        {
            List<BLVolunteerModel> list = Convert(Volunteer.Read((Func<Volunteer, bool>)func).Result);
            return list;
        }

        public async Task<List<BLVolunteerModel>> ReadAll()
        {
            List<BLVolunteerModel> list = new List<BLVolunteerModel>();

            Volunteer.ReadAll().Result.ForEach(item => { list.Add(Convert(item)); });

            return list;
        }

        public void Update(BLVolunteerModel item)
        {
            Volunteer.Update(Convert(item));
        }
    }
}
