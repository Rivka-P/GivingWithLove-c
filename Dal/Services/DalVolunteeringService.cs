//using Dal.Api;
//using Dal.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dal.Services
//{
//    public class DalVolunteeringService:DalVolunteeringInterface
//    {
//        DbManager mydb;
//        public DalVolunteeringService(DbManager mydb)
//        {
//            this.mydb = mydb;
//        }

//        public void Create(Volunteering volunteering)
//        {
//            if (volunteering == null)
//                throw new ArgumentNullException("volunteering is null");
//            else
//                try
//                {
//                    mydb.Volunteerings.Add(volunteering);
//                    try { mydb.SaveChanges(); }
//                    catch
//                    {
//                        mydb.Volunteerings.Remove(volunteering);
//                        throw new Exception("yyyyyyyyyyy");
//                    }
//                }
//                catch
//                {
//                    throw new Exception("lllllllllllll");
//                }
//        }


//        //public void Delete(Volunteering volunteering)
//        //{
//        //    if (volunteering == null)
//        //        throw new ArgumentNullException("item");
//        //    var existingVolunteering = mydb.Volunteerings.Find(volunteering.VolunteeringCode);
//        //    if (existingVolunteering == null)
//        //    {
//        //        throw new InvalidOperationException("The volunteering record does not exist.");
//        //    }
//        //    mydb.Volunteerings.Remove(existingVolunteering);
//        //    mydb.SaveChanges();

//        //}
//        public void Delete(Volunteering volunteering)
//        {
//            if (volunteering == null)
//                throw new ArgumentNullException(nameof(volunteering), "The volunteering object cannot be null.");

//                var existingVolunteering = ReadAll().Result.Find(v => v.VolunteeringCode == volunteering.VolunteeringCode);
//            if (existingVolunteering == null)
//                throw new InvalidOperationException("The volunteering record does not exist.");

//            mydb.Volunteerings.Remove(existingVolunteering);
//            mydb.SaveChanges();
//        }

//        public async Task<List<Volunteering>> Read(Func<Volunteering, bool> func)
//        {
//            List<Volunteering> list = new();
//            foreach (Volunteering item in mydb.Volunteerings)
//                if (func(item))
//                    list.Add(item);
//              return list;
//        }

//        public async Task<Volunteering> Read(int id)
//        {

//            Volunteering v = mydb.Volunteerings.ToList().Find(v => v.VolunteeringCode == id)?? throw new ObjectNotFoundException();
//            return v;
//        }
//        public async Task<List<Volunteering>> ReadAll()
//        {
//            return mydb.Volunteerings.ToList();
//        }



//        public void Update(Volunteering volunteering)
//        {
//            try
//            {
//                var i = ReadAll().Result.FindIndex(v => v.VolunteeringCode ==volunteering.VolunteeringCode);
//                if (i >= 0)
//                {
//                    mydb.Volunteerings.ToList<Volunteering>()[i] = volunteering;
//                   mydb.SaveChanges();
//                }

//            }
//            catch { Console.WriteLine("Category not found"); }

//        }


//    }
//}

using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class DalVolunteeringService : DalVolunteeringInterface
{
    private readonly DbManager _mydb;

    public DalVolunteeringService(DbManager mydb)
    {
        _mydb = mydb;
    }

    // Create - שדרוג טיפול בשגיאות
    public void Create(Volunteering volunteering)
    {
        if (volunteering == null)
            throw new ArgumentNullException(nameof(volunteering), "The volunteering object cannot be null.");

        try
        {
            _mydb.Volunteerings.Add(volunteering);
            _mydb.SaveChanges();
        }
        catch (Exception ex)
        {
            // לוג על בעיה במהלך שמירה
            throw new Exception("An error occurred while saving the volunteering record.", ex);
        }
    }

    // Delete
    public void Delete(Volunteering volunteering)
    {
        if (volunteering == null)
            throw new ArgumentNullException(nameof(volunteering), "The volunteering object cannot be null.");

        var existingVolunteering = _mydb.Volunteerings
                                         .FirstOrDefault(v => v.VolunteeringCode == volunteering.VolunteeringCode);
        if (existingVolunteering == null)
            throw new InvalidOperationException("The volunteering record does not exist.");

        _mydb.Volunteerings.Remove(existingVolunteering);
        _mydb.SaveChanges();
    }

    // Read by Func
    public async Task<List<Volunteering>> Read(Func<Volunteering, bool> func)
    {
        return await Task.Run(() => _mydb.Volunteerings.Where(func).ToList());
    }

    // Read by ID
    public async Task<Volunteering> Read(int id)
    {
        try
        {
            var volunteering = await _mydb.Volunteerings
                .FirstOrDefaultAsync(v => v.VolunteeringCode == id);

            if (volunteering == null)
                throw new ObjectNotFoundException($"No volunteering record found with ID {id}.");

            return volunteering;
        }
        catch (ObjectNotFoundException ex)
        {
            // לוג עם פרטים נוספים
            throw;
        }
        catch (Exception ex)
        {
            
            throw new Exception("An unexpected error occurred while fetching the volunteering record.", ex);
        }
    }

    // ReadAll
    public async Task<List<Volunteering>> ReadAll()
    {
        return await _mydb.Volunteerings.ToListAsync();
    }

    // Update
    public void Update(Volunteering volunteering)
    {
        try
        {
            var existingVolunteering = _mydb.Volunteerings
                                            .FirstOrDefault(v => v.VolunteeringCode == volunteering.VolunteeringCode);
            if (existingVolunteering == null)
                throw new InvalidOperationException("The volunteering record does not exist.");

            // עדכון הנתונים
            _mydb.Entry(existingVolunteering).CurrentValues.SetValues(volunteering);
            _mydb.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the volunteering record.", ex);
        }
    }
}