using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalPositionService : DalPositionInterface
    {
        DbManager mydb;
        public DalPositionService(DbManager mydb)
        {
            this.mydb = mydb;
        }



        //public async Task<Volunteering> Read(int id)
        //{
        //    Volunteering v = mydb.Volunteerings.Find(v => v.VolunteerCode == id);
        //    return v;
        //}
        //public async Task<List<Volunteering>> ReadAll()
        //{
        //    return mydb.Volunteerings.ToList();
        //}



        //public void Update(Volunteering volunteering)
        //{
        //    try
        //    {
        //        var i = ReadAll().Result.FindIndex(v => v.VolunteeringCode == volunteering.VolunteeringCode);
        //        if (i >= 0)
        //        {
        //            mydb.Volunteerings.ToList<Volunteering>()[i] = volunteering;
        //            mydb.SaveChanges();
        //        }

        //    }
        //    catch { Console.WriteLine("Category not found"); }

        //}

        public void Create(Position item)
        {
            if (item == null)
                throw new ArgumentNullException("Position is null");
            else
                try
                {
                    mydb.Positions.Add(item);
                    mydb.SaveChanges();
                }
                catch
                {
                    throw new Exception();
                }
        }

        public void Delete(Position item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            mydb.Positions.Remove(item);
            mydb.SaveChanges();
        }

        public async Task<Position> Read(int id)
        {
            Position p = mydb.Positions.Where(x=> x.PositionCode == id).FirstOrDefault();
            return p;
        }

        public async Task<List<Position>> Read(Func<Position, bool> func)
        {
            List<Position> list = new();
            foreach (Position item in mydb.Positions)
                if (func(item))
                    list.Add(item);
            return list;
        }

        public async Task<List<Position>> ReadAll()
        {
            return mydb.Positions.ToList();
        }

        public void Update(Position item)
        {
            try
            {
                var i = ReadAll().Result.FindIndex(v => v.PositionCode == item.PositionCode);
                if (i >= 0)
                {
                    mydb.Positions.ToList<Position>()[i] = item;
                    mydb.SaveChanges();
                }

            }
            catch { Console.WriteLine("Position not found"); }
        }
    }
}
