using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalEichudService : DalEichudInterface
    {
        private DbManager dbm;

        public DalEichudService(DbManager dbm)
        {
            this.dbm = dbm;
        }

        public async Task CreateAsync(Eichud item)
        {
            await dbm.Eichuds.AddAsync(item);
            await dbm.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await dbm.Eichuds.FirstOrDefaultAsync(e => e.EichudCode == id);
            if (item != null)
            {
                dbm.Eichuds.Remove(item);
                await dbm.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("the EichudCode do not found");
                throw new ArgumentNullException("the EichudCode do not found");
            }
        }

        public async Task DeleteAsync(Eichud item)
        {
            await DeleteAsync(item.EichudCode);
        }

        public async Task<List<Eichud>> ReadAsync(Func<Eichud, bool> func)
        {
            var all = await dbm.Eichuds.ToListAsync();
            return all.Where(func).ToList();
        }

        public async Task<Eichud> ReadAsync(int id)
        {
            var e = await dbm.Eichuds.FirstOrDefaultAsync(x => x.EichudCode == id)
                     ?? throw new ObjectNotFoundException();
            return e;
        }

        public async Task<List<Eichud>> ReadAllAsync()
        {
            return await dbm.Eichuds.ToListAsync();
        }

        public async Task UpdateAsync(Eichud item)
        {
            var existing = await dbm.Eichuds.FirstOrDefaultAsync(x => x.EichudCode == item.EichudCode);
            if (existing != null)
            {
                dbm.Entry(existing).CurrentValues.SetValues(item);
                await dbm.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("EichudCode not found");
                throw new Exception("EichudCode not found");
            }
        }
    }
}