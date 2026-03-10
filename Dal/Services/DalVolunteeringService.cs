using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalVolunteeringService:DalVolunteeringInterface
    {
        DbManager mydb;
        public DalVolunteeringService(DbManager mydb)
        {
            this.mydb = mydb;
        }

        public void Create(Volunteering volunteering)
        {
            if (volunteering == null)
                throw new ArgumentNullException("volunteering is null");
            else
                try
                {
                    mydb.Volunteerings.Add(volunteering);
                    mydb.SaveChanges();
                }
                catch
                {
                    throw new Exception();
                }
        }

       
        public void Delete(Volunteering volunteering)
        {
            if (volunteering == null)
                throw new ArgumentNullException("item");
            mydb.Volunteerings.Remove(volunteering);
            mydb.SaveChanges();
        }

       public async Task<List<Volunteering>> Read(Func<Volunteering, bool> func)
        {
            List<Volunteering> list = new();
            foreach (Volunteering item in mydb.Volunteerings)
                if (func(item))
                    list.Add(item);
              return list;
        }

        public async Task<Volunteering> Read(int id)
        {
            Volunteering v =await mydb.Volunteerings.FirstOrDefaultAsync(v => v.VolunteerCode == id);
            return v;
        }
        public async Task<List<Volunteering>> ReadAll()
        {
            return mydb.Volunteerings.ToList();
        }

        

        public void Update(Volunteering volunteering)
        {
            try
            {
                var i = ReadAll().Result.FindIndex(v => v.VolunteeringCode ==volunteering.VolunteeringCode);
                if (i >= 0)
                {
                    mydb.Volunteerings.ToList<Volunteering>()[i] = volunteering;
                   mydb.SaveChanges();
                }

            }
            catch { Console.WriteLine("Category not found"); }
           
        }

       
    }
}
  
