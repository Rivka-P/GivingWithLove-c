
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalVolunteeringService : DalVolunteeringInterface
    {
        private readonly DbManager mydb;

        public DalVolunteeringService(DbManager mydb)
        {
            this.mydb = mydb;
        }
        public async Task CreateAsync(Volunteering volunteering)
        {
            if (volunteering == null)
                throw new ArgumentNullException(nameof(volunteering));

            await mydb.Volunteerings.AddAsync(volunteering);
            await mydb.SaveChangesAsync();
        }

        public async Task DeleteAsync(Volunteering volunteering)
        {
            if (volunteering == null)
                throw new ArgumentNullException(nameof(volunteering));

            mydb.Volunteerings.Remove(volunteering);
            await mydb.SaveChangesAsync();
        }

        public async Task<Volunteering> ReadAsync(int id)
        {
            var vm = await mydb.Volunteerings
                                .FirstOrDefaultAsync(v => v.VolunteeringCode == id);

            if (vm == null)
                throw new ObjectNotFoundException();

            return vm;
        }

        public async Task<List<Volunteering>> ReadAllAsync()
        {
            return await mydb.Volunteerings.ToListAsync();
        }

        public async Task<List<Volunteering>> ReadAsync(Func<Volunteering, bool> func)
        {
            // לצערי EF לא תומך ב־Func סינכרוני עם IQueryable, אז צריך להשתמש ב־ToListAsync()
            var list = await mydb.Volunteerings.ToListAsync();
            return list.Where(func).ToList();
        }

        public async Task UpdateAsync(Volunteering volunteering)
        {
            if (volunteering == null)
                throw new ArgumentNullException(nameof(volunteering));

            var existing = await mydb.Volunteerings
                                     .FirstOrDefaultAsync(v => v.VolunteeringCode == volunteering.VolunteeringCode);

            if (existing == null)
                throw new ObjectNotFoundException();

            // עדכון השדות
            existing.VolunteerCode = volunteering.VolunteerCode;
            existing.ProjectCode = volunteering.ProjectCode;

            await mydb.SaveChangesAsync();
        }
    }


    public static class VolunteerExtensions
    {
        public static string FullName(this Volunteer v) => $"{v.FullName} ";
    }
}
