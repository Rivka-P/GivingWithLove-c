using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalEichudService:DalEichudInterface
    {
        private DbManager dbm;

        public DalEichudService(DbManager dbm)
        {
            this.dbm = dbm;
        }

        public void Create(Eichud item)
        {
            dbm.Eichuds.Add(item);
            dbm.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var item = ReadAll().Result.Find(b => b.EichudCode == id);
                if (item != null)
                {
                    dbm.Eichuds.Remove(item);
                    dbm.SaveChanges();
                }
            }
            catch {Console.WriteLine("the EicudCode do not found");
                throw new ArgumentNullException("the EicudCode do not found");}
        }

        public void Delete(Eichud item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Eichud>> Read(Func<Eichud, bool> func)
        {
            List<Eichud> list = new List<Eichud>();

            foreach (Eichud item in dbm.Eichuds)
                if (func(item)) 
                    list.Add(item);

            return list;
        }

        public async Task<Eichud> Read(int id)
        {
            Eichud e = dbm.Eichuds.Where(x => x.EichudCode == id).FirstOrDefault();
            return e;
        }

       
        public async Task<List<Eichud>> ReadAll()
        {
            return dbm.Eichuds.ToList();
        }


        public void Update(Eichud item)
        {
            try
            {
                var i = ReadAll().Result.FindIndex(b => b.EichudCode == item.EichudCode);
                if (i >= 0)
                {
                    dbm.Eichuds.ToList<Eichud>()[i] = item;
                    dbm.SaveChanges();
                }

            }
            catch {
                Console.WriteLine("EicudCode not found");
                throw new Exception("EicudCode not found");
            }
        }
    }
}
