using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalVolunteerDomainService : DalVolunteerDomainInterface
    {
        private readonly DbManager mydb;

        public DalVolunteerDomainService(DbManager mydb)
        {
            this.mydb = mydb;
        }

        public async Task CreateAsync(VolunteerDomain volunteerDomain)
        {
            if (volunteerDomain == null)
                throw new ArgumentNullException(nameof(volunteerDomain));

            await mydb.VolunteerDomains.AddAsync(volunteerDomain);
            await mydb.SaveChangesAsync();
        }

        public async Task DeleteAsync(VolunteerDomain volunteerDomain)
        {
            if (volunteerDomain == null)
                throw new ArgumentNullException(nameof(volunteerDomain));

            mydb.VolunteerDomains.Remove(volunteerDomain);
            await mydb.SaveChangesAsync();
        }

        public async Task<VolunteerDomain> ReadAsync(int id)
        {
            var vm = await mydb.VolunteerDomains
                                .FirstOrDefaultAsync(v => v.VolunteerDomainsCode == id);

            if (vm == null)
                throw new ObjectNotFoundException();

            return vm;
        }

        public async Task<List<VolunteerDomain>> ReadAllAsync()
        {
            return await mydb.VolunteerDomains.ToListAsync();
        }

        public async Task<List<VolunteerDomain>> ReadAsync(Func<VolunteerDomain, bool> func)
        {
            // לצערי EF לא תומך ב־Func סינכרוני עם IQueryable, אז צריך להשתמש ב־ToListAsync()
            var list = await mydb.VolunteerDomains.ToListAsync();
            return list.Where(func).ToList();
        }

        public async Task UpdateAsync(VolunteerDomain volunteerDomain)
        {
            if (volunteerDomain == null)
                throw new ArgumentNullException(nameof(volunteerDomain));

            var existing = await mydb.VolunteerDomains
                                     .FirstOrDefaultAsync(v => v.VolunteerDomainsCode == volunteerDomain.VolunteerDomainsCode);

            if (existing == null)
                throw new ObjectNotFoundException();

            // עדכון השדות
            existing.VolunteerCode = volunteerDomain.VolunteerCode;
            existing.ProjectCode = volunteerDomain.ProjectCode;

            await mydb.SaveChangesAsync();
        }
    }
}