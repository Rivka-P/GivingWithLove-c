using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalSubProjectService : DalSubProjectInterface
    {
        private DbManager db;

        public DalSubProjectService(DbManager dbm)
        {
            db = dbm;
        }
        public void Create(SubProject item)
        {
            db.SubProjects.Add(item);
            db.SaveChanges();
        }

        public void Delete(SubProject item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            // שאילתא ששולפת את הפריט ואז לעשות רימוב

            db.SubProjects.Remove
                (db.SubProjects.Where(x => x.SubProjectCode == item.SubProjectCode).FirstOrDefault()
                            ?? throw new Exception("לא נמצא הפריט למחיקה"));
            db.SaveChanges();
        }

        public Task<SubProject> Read(int id)
        {
            throw new NotImplementedException();

        }

     

        public async Task<List<SubProject>> Read(Func<SubProject, bool> func)
        {
           
            List<SubProject> list = new List<SubProject>();
            foreach (SubProject item in db.SubProjects)
                if (func(item))
                    list.Add(item);
            return list;           
        }

        public async Task<List<SubProject>> ReadAll() => db.SubProjects.ToList();

        public void Update(SubProject item)
        {
            try
            {
                var i = ReadAll().Result.FindIndex(v => v.SubProjectCode == item.SubProjectCode);
                if (i >= 0)
                {
                    db.SubProjects.ToList<SubProject>()[i] = item;
                    db.SaveChanges();
                }

            }
            catch { Console.WriteLine("SubProject not found"); }

        }
        
    }
}
