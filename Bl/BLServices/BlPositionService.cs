using Bl.BLApi;
using Bl.BLModels;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private BlPositionModel convert(Position p)
        {
            return new BlPositionModel()
            {
                positionCode = p.positionCode,
                positionName = p.positionName
            };
        }
        private Position convert(BlPositionModel p)
        {
            return new Position()
            {
                positionCode = p.positionCode,
                positionName = p.positionName
            };
        }
        private List<BlPositionModel> convert(List<Position> p)
        {
            List<BlPositionModel> list = new List<BlPositionModel>();
            foreach (var item in p)
            {
                list.Add(convert(item));
            }
            return list;
        }

        public void Create(BlPositionModel item)
        {
            dal.Create(convert(item));
        }

        public void Delete(BlPositionModel item)
        {
            dal.Delete(convert(item));
        }

        public async Task<BlPositionModel> Read(int id)
        {
            return convert(dal.Read(id).Result);
        }

        public async Task<List<BlPositionModel>> Read(Func<BlPositionModel, bool> func)
        {
            List<BlPositionModel> list =
                convert(dal.Read((Func<Position, bool>)func).Result);
                return list;
        }

        public async Task<List<BlPositionModel>> ReadAll()
        {
            List<BlPositionModel> list = new List<BlPositionModel>();
            dal.ReadAll().Result.ForEach(item => { list.Add(convert(item)); });
            //convert(dal.ReadAll().Result);
            return list;
        }

        public void Update(BlPositionModel item)
        {
            dal.Update(convert(item));
        }
    }
}
