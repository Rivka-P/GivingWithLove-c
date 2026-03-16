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
    public class BlEichudService : BlEichudInterface
    {
        DalEichudInterface dal;
        public BlEichudService(IDal dal)
        {
            this.dal = dal.Eichud;
        }
        private  BlEichudModel convert(Eichud eichud)
        {
            return new BlEichudModel(){
                EichudCode = eichud.EichudCode,
                Tohar = eichud.Tohar,
                FamilyName = eichud.FamilyName,
                FirstName = eichud.FirstName,
                Ending = eichud.Ending,
                FathersName = eichud.FathersName,
                Shtibel = eichud.Shtibel,
                Street = eichud.Street,
                House = eichud.House,
                City = eichud.City,
                ZipCode = eichud.ZipCode,
                HousePhone = eichud.HousePhone,
                CellPhone = eichud.CellPhone,
                Shver = eichud.Shver
            };
        }
        private Eichud convert(BlEichudModel eichud)
        {
            return new Eichud()
            {
                EichudCode = eichud.EichudCode,
                Tohar = eichud.Tohar,
                FamilyName = eichud.FamilyName,
                FirstName = eichud.FirstName,
                Ending = eichud.Ending,
                FathersName = eichud.FathersName,
                Shtibel = eichud.Shtibel,
                Street = eichud.Street,
                House = eichud.House,
                City = eichud.City,
                ZipCode = eichud.ZipCode,
                HousePhone = eichud.HousePhone,
                CellPhone = eichud.CellPhone,
                Shver = eichud.Shver
            };
        }
        private List<BlEichudModel> convert(List<Eichud> v)
        {
            List<BlEichudModel> list = new List<BlEichudModel>();
            foreach (var item in v)
            {
                list.Add(convert(item));
            }
            return list;
        }
        public void Create(BlEichudModel item)
        {
            dal.Create(convert(item));
        }

        public void Delete(BlEichudModel item)
        {
            dal.Delete(convert(item));
        }

        public async Task<List<BlEichudModel>> Read(Func<BlEichudModel, bool> func)
        {

            List<BlEichudModel> list = convert(dal.Read((Func<Eichud, bool>)func).Result);
            return list;
        }

<<<<<<< HEAD
        public async Task<BlEichudModel> Read(BlEichudModel item)
        {
            return convert(dal.Read(convert(item).EichudCode).Result);
=======
        public async Task<BlEichudModel> Read(int id)
        {
            try { return convert(dal.Read(id).Result); }
            catch (ObjectNotFoundException e)
            {
                return null;
            }
            //return convert(dal.Read(convert(item).Result));
>>>>>>> refs/remotes/origin/main
        }

        public async Task<List<BlEichudModel>> ReadAll()
        {
            List<BlEichudModel> list = new List<BlEichudModel>();
            dal.ReadAll().Result.ForEach(item => { list.Add(convert(item)); });
            return list;
        }

        public void Update(BlEichudModel item)
        {
            dal.Update(convert(item));
        }

        public Task<BlEichudModel> Read(int id)
        {
            throw new NotImplementedException();
        }
    }
}
