using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateAsync(SubProject item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            await db.SubProjects.AddAsync(item);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(SubProject item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var entity = await db.SubProjects.FirstOrDefaultAsync(x => x.SubProjectCode == item.SubProjectCode);
            if (entity == null) throw new Exception("לא נמצא הפריט למחיקה");

            db.SubProjects.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<SubProject> ReadAsync(int id)
        {
            var sp = await db.SubProjects.FirstOrDefaultAsync(v => v.SubProjectCode == id);
            return sp ?? throw new ObjectNotFoundException();
        }

        public async Task<List<SubProject>> ReadAsync(Func<SubProject, bool> func)
        {
            // לא ניתן להריץ LINQ עם Func באופן אסינכרוני על DBSet
            var all = await db.SubProjects.ToListAsync();
            return all.Where(func).ToList();
        }

        public async Task<List<SubProject>> ReadAllAsync()
        {
            return await db.SubProjects.ToListAsync();
        }

        public async Task UpdateAsync(SubProject item)
        {
            var existing = await db.SubProjects.FirstOrDefaultAsync(v => v.SubProjectCode == item.SubProjectCode);
            if (existing == null)
            {
                Console.WriteLine("SubProject not found");
                throw new Exception("SubProject not found");
            }

            // עדכון השדות
            existing.ProjectCode = item.ProjectCode;
            existing.SubProjectName = item.SubProjectName;
            existing.EstimatedTime = item.EstimatedTime;
            existing.EstimatedCost = item.EstimatedCost;

            await db.SaveChangesAsync();
        }
    }
}