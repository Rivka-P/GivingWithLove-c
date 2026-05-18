using Bl.BLApi;
using Bl.BLModels;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bl.BLServices
{
    public class BlPositionService : BlPositionInterface
    {
        DalPositionInterface dal;
        public BlPositionService(IDal dal)
        {
            this.dal = dal.Position;
        }

        private BlPositionModel convert(Position p) => new BlPositionModel()
        {
            positionCode = p.positionCode,
            positionName = p.positionName
        };

        private Position convert(BlPositionModel p) => new Position()
        {
            positionCode = p.positionCode,
            positionName = p.positionName
        };

        private List<BlPositionModel> convert(List<Position> p) =>
            p.Select(convert).ToList();

        public async Task CreateAsync(BlPositionModel item)
        {
            await dal.CreateAsync(convert(item));
        }

        public async Task DeleteAsync(BlPositionModel item)
        {
            await dal.DeleteAsync(convert(item));
        }

        public async Task<BlPositionModel> ReadAsync(int id)
        {
            var data = await dal.ReadAsync(id);
            return convert(data);
        }

        public async Task<List<BlPositionModel>> ReadAsync(Func<BlPositionModel, bool> func)
        {
            var data = await dal.ReadAllAsync();
            return data
                .Select(convert)
                .Where(func)
                .ToList();
        }

        public async Task<List<BlPositionModel>> ReadAllAsync()
        {
            var data = await dal.ReadAllAsync();
            return convert(data);
        }

        public async Task UpdateAsync(BlPositionModel item)
        {
            await dal.UpdateAsync(convert(item));
        }
    }
}