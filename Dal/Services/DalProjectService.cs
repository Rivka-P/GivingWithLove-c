using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalProjectService : DalProjectInterface
    {
        private DbManager db;

        public DalProjectService(DbManager dbm)
        {
            db = dbm;
        }
        public void Create(Project item)
        {
            db.Projects.Add(item);
            db.SaveChanges();
        }

        public void Delete(Project item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            // שאילתא ששולפת את הפריט ואז לעשות רימוב

            db.Projects.Remove
                (db.Projects.Where(x => x.ProjectCode == item.ProjectCode).FirstOrDefault()
                            ?? throw new Exception("לא נמצא הפריט למחיקה"));
            db.SaveChanges();
        }

        public async Task<Project> Read(int id)
        {
            Project p = db.Projects.ToList().Find(v => v.ProjectCode == id) ?? throw new ObjectNotFoundException();
            return p;
        }

        public async Task<List<Project>> Read(Func<Project, bool> func)
        {
            List<Project> list = new List<Project>();
            foreach (Project item in db.Projects)
                if (func(item))
                    list.Add(item);
            return list;
           
        }

        public async Task<List<Project>> ReadAll() => db.Projects.ToList();
       
        public void Update(Project item)
        {
            try
            {
                var i = ReadAll().Result.FindIndex(v => v.ProjectCode == item.ProjectCode);
                if (i >= 0)
                {
                    db.Projects.ToList<Project>()[i] = item;
                    db.SaveChanges();
                }

            }
            catch { Console.WriteLine("Project not found"); }
        }


        //public void Create(Project item)
        //{
        //    throw new NotImplementedException();
        //}



        //public void Delete(Project item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Project> Read(int id)
        //{
        //    throw new NotImplementedException();
        //}



        //public Task<List<Project>> Read(Func<Project, bool> func)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<Project>> ReadAll()
        //{
        //    throw new NotImplementedException();
        //}


        //public void Update(Project item)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Project> ICrud<Project>.Read(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<Project>> ICrud<Project>.ReadAll()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
