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
    public class BlEichudService : BlEichudInterface
    {
        DalEichudInterface dal;
        public BlEichudService(IDal dal)
        {
            this.dal = dal.Eichud;
        }
        public BlEichudModel convert(Eichud eichud)
        {
            return new BlEichudModel()
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

        public Eichud convert(BlEichudModel eichud)
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

        public List<BlEichudModel> convert(List<Eichud> v)
        {
            List<BlEichudModel> list = new List<BlEichudModel>();
            foreach (var item in v)
            {
                list.Add(convert(item));
            }
            return list;
        }

        public async Task CreateAsync(BlEichudModel item)
        {
            await dal.CreateAsync(convert(item));
        }

        public async Task DeleteAsync(BlEichudModel item)
        {
            await dal.DeleteAsync(convert(item));
        }

        public async Task<List<BlEichudModel>> ReadAsync(Func<BlEichudModel, bool> func)
        {
            var all = await dal.ReadAsync((Func<Eichud, bool>)(e => func(convert(e))));
            return convert(all);
        }

        public async Task<BlEichudModel> ReadAsync(int id)
        {
            try
            {
                var item = await dal.ReadAsync(id);
                return convert(item);
            }
            catch (ObjectNotFoundException)
            {
                return null;
            }
        }

        public async Task<List<BlEichudModel>> ReadAllAsync()
        {
            var all = await dal.ReadAllAsync();
            return convert(all);
        }

        public async Task UpdateAsync(BlEichudModel item)
        {
            await dal.UpdateAsync(convert(item));
        }
    }
}