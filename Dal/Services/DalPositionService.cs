using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateAsync(Position item)
        {
            if (item == null)
                throw new ArgumentNullException("Position is null");

            await mydb.Positions.AddAsync(item);
            await mydb.SaveChangesAsync();
        }

        public async Task DeleteAsync(Position item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            mydb.Positions.Remove(item);
            await mydb.SaveChangesAsync();
        }

        public async Task<Position> ReadAsync(int id)
        {
            var p = await mydb.Positions.FirstOrDefaultAsync(x => x.positionCode == id)
                     ?? throw new ObjectNotFoundException();
            return p;
        }

        public async Task<List<Position>> ReadAsync(Func<Position, bool> func)
        {
            var all = await mydb.Positions.ToListAsync();
            return all.Where(func).ToList();
        }

        public async Task<List<Position>> ReadAllAsync()
        {
            return await mydb.Positions.ToListAsync();
        }

        public async Task UpdateAsync(Position item)
        {
            var existing = await mydb.Positions.FirstOrDefaultAsync(x => x.positionCode == item.positionCode);
            if (existing != null)
            {
                mydb.Entry(existing).CurrentValues.SetValues(item);
                await mydb.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Position not found");
                throw new Exception("Position not found");
            }
        }
    }
}