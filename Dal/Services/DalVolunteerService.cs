using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalVolunteerService : DalSubProjectInterfase
    {

        private DbManager db;

        public DalVolunteerService(DbManager dbm)
        {
            db = dbm;
        }

        public void Create(Volunteer item)
        {
            db.Volunteers.Add(item);
            db.SaveChanges();

            
        }

        

        public void Delete(Volunteer item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            // שאילתא ששולפת את הפריט ואז לעשות רימוב

            db.Volunteers.Remove
                (db.Volunteers.Where(x => x.VolunteerCode == item.VolunteerCode).FirstOrDefault()
                            ?? throw new Exception("לא נמצא הפריט למחיקה"));
            db.SaveChanges();
            //throw new NotImplementedException();
        }

       
        public async Task<List<Volunteer>> Read(Func<Volunteer, bool> func)
        {
            List<Volunteer> list = new();
            foreach (Volunteer item in db.Volunteers)
                if (func(item))
                    list.Add(item);
            return list;
        }
        public async Task<Volunteer> Read(int id)
        {
            Volunteer v = db.Volunteers.Find(v => v.VolunteerCode == id);
            return v;
        }


        public async Task<List<Volunteer>> ReadAll() => db.Volunteers.ToList();
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(Volunteer item)
        {
            try
            {
                var i = ReadAll().Result.FindIndex(v => v.VolunteerCode == item.VolunteerCode);
                if (i >= 0)
                {
                    db.Volunteers.ToList<Volunteer>()[i] = item;
                    db.SaveChanges();
                }

            }
            catch { Console.WriteLine("Volunteer not found"); }

        }
    }
}
