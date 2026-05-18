////using Dal.Api;
////using Dal.Models;
////using Microsoft.EntityFrameworkCore;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Threading.Tasks;

////namespace Dal.Services
////{
////    public class DalVolunteerService : DalVolunteerInterface
////    {
////        private DbManager db;

////        public DalVolunteerService(DbManager dbm)
////        {
////            db = dbm;
////        }

////        public async Task CreateAsync(Volunteer item)
////        {
////            db.Volunteers.Add(item);
////            await db.SaveChangesAsync();
////        }

////        public async Task DeleteAsync(Volunteer item)
////        {
////            if (item == null)
////                throw new ArgumentNullException("item");

////            var entity = await db.Volunteers
////                                 .Where(x => x.VolunteerCode == item.VolunteerCode)
////                                 .FirstOrDefaultAsync();

////            if (entity == null)
////                throw new Exception("לא נמצא הפריט למחיקה");

////            db.Volunteers.Remove(entity);
////            await db.SaveChangesAsync();
////        }

////        public async Task<List<Volunteer>> ReadAsync(Func<Volunteer, bool> func)
////        {
////            List<Volunteer> list = new();
////            foreach (Volunteer item in await ReadAllAsync())
////                if (func(item))
////                    list.Add(item);
////            return list;
////        }

////        public async Task<Volunteer> ReadAsync(int id)
////        {
////            var all = await ReadAllAsync();
////            Volunteer v = all.Find(v => v.VolunteerCode == id) ?? throw new ObjectNotFoundException();
////            return v;
////        }

////        public async Task<List<Volunteer>> ReadAllAsync()
////        {
////            return await db.Volunteers
////                           .Include(x => x.VolunteerCodeNavigation)
////                           .ToListAsync();
////        }

////        public async Task UpdateAsync(Volunteer item)
////        {
////            try
////            {
////                var all = await ReadAllAsync();
////                int i = all.FindIndex(v => v.VolunteerCode == item.VolunteerCode);
////                if (i >= 0)
////                {
////                    db.Volunteers.Update(item);
////                    await db.SaveChangesAsync();
////                }
////            }
////            catch
////            {
////                Console.WriteLine("Volunteer not found");
////            }
////        }
////    }
////}
//using Dal.Api;
//using Dal.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Dal.Services
//{
//    public class DalVolunteerService : DalVolunteerInterface
//    {
//        private readonly DbManager db;

//        public DalVolunteerService(DbManager dbm)
//        {
//            db = dbm;
//        }

//        public async Task CreateAsync(Volunteer item)
//        {
//            db.Volunteers.Add(item);
//            await db.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(Volunteer item)
//        {
//            if (item == null)
//                throw new ArgumentNullException(nameof(item));

//            var entity = await db.Volunteers
//                .FirstOrDefaultAsync(x => x.VolunteerCode == item.VolunteerCode);

//            if (entity == null)
//                throw new Exception("לא נמצא הפריט למחיקה");

//            db.Volunteers.Remove(entity);
//            await db.SaveChangesAsync();
//        }

//        public async Task<List<Volunteer>> ReadAsync(Func<Volunteer, bool> func)
//        {
//            var list = await db.Volunteers
//                .Include(x => x.VolunteerCodeNavigation)
//                .ToListAsync();

//            return list.Where(func).ToList();
//        }

//        public async Task<Volunteer> ReadAsync(int id)
//        {
//            return await db.Volunteers
//                .Include(x => x.VolunteerCodeNavigation)
//                .FirstOrDefaultAsync(v => v.VolunteerCode == id)
//                ?? throw new ObjectNotFoundException();
//        }

//        public async Task<List<Volunteer>> ReadAllAsync()
//        {
//            return await db.Volunteers
//                .Include(x => x.VolunteerCodeNavigation)
//                .ToListAsync();
//        }

//        public async Task UpdateAsync(Volunteer item)
//        {
//            var entity = await db.Volunteers
//                .FirstOrDefaultAsync(v => v.VolunteerCode == item.VolunteerCode);

//            if (entity == null)
//                throw new Exception("Volunteer not found");

//            db.Entry(entity).CurrentValues.SetValues(item);
//            await db.SaveChangesAsync();
//        }
//    }
//}
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalVolunteerService : DalVolunteerInterface
    {
        private readonly DbManager db;

        public DalVolunteerService(DbManager dbm)
        {
            db = dbm;
        }

        public async Task CreateAsync(Volunteer item)
        {
            db.Volunteers.Add(item);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Volunteer item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var entity = await db.Volunteers
                .FirstOrDefaultAsync(x => x.VolunteerCode == item.VolunteerCode);

            if (entity == null)
                return;

            db.Volunteers.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<Volunteer?> ReadAsync(int id)
        {
            return await db.Volunteers
                .Include(x => x.VolunteerCodeNavigation)
                .FirstOrDefaultAsync(v => v.VolunteerCode == id);
        }

        public async Task<List<Volunteer>> ReadAllAsync()
        {
            return await db.Volunteers
                .Include(x => x.VolunteerCodeNavigation)
                .ToListAsync();
        }

        public async Task UpdateAsync(Volunteer item)
        {
            var entity = await db.Volunteers
                .FirstOrDefaultAsync(v => v.VolunteerCode == item.VolunteerCode);

            if (entity == null)
                return;

            db.Entry(entity).CurrentValues.SetValues(item);
            await db.SaveChangesAsync();
        }

        public async Task<List<Volunteer>> ReadAsync(Func<Volunteer, bool> func)
        {
            var list = await ReadAllAsync();
            return list.Where(func).ToList();
        }
    }
}