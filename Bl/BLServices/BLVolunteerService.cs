//using Bl.BLApi;
//using Bl.BLModels;
//using Dal.Api;
//using Dal.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Bl.BLServices
//{
//    public class BLVolunteerService : BlVolunteerInterface
//    {
//        private readonly DalVolunteerInterface _volunteerDal;
//        private readonly BlEichudInterface _blEichud;
//        private readonly BlVolunteerDomainInterface _blDomain;
//        private readonly BlPositionInterface _blPosition;

//        public BLVolunteerService(IDal dal, BlEichudInterface blEichud, BlVolunteerDomainInterface blDomain, BlPositionInterface blPosition)
//        {
//            _volunteerDal = dal?.Volunteer ?? throw new ArgumentNullException(nameof(dal));
//            _blEichud = blEichud ?? throw new ArgumentNullException(nameof(blEichud));
//            _blDomain = blDomain ?? throw new ArgumentNullException(nameof(blDomain));
//            _blPosition = blPosition ?? throw new ArgumentNullException(nameof(blPosition));
//        }

//        private Volunteer ConvertToDal(BLVolunteerModel v)
//        {
//            if (v == null) return null;

//            return new Volunteer()
//            {
//                VolunteerCode = v.VolunteerCode,
//                PositionCode = v.PositionCode,
//                VolunteerDomains = v.VolunteerDomains?.Select(x => _blDomain.Convert(x)).ToList() ?? new List<VolunteerDomain>()
//            };
//        }

//        private async Task<BLVolunteerModel> ConvertToBlAsync(Volunteer v)
//        {
//            if (v == null) return null;

//            var blv = new BLVolunteerModel()
//            {
//                VolunteerCode = v.VolunteerCode,
//                PositionCode = v.PositionCode,
//                VolunteerCodeNavigation = _blEichud.Convert(v.VolunteerCodeNavigation),
//                VolunteerDomains = v.VolunteerDomains?.Select(x => _blDomain.Convert(x)).ToList() ?? new List<BLVolunteerDomainModel>()
//            };

//            if (blv.PositionCode.HasValue)
//            {
//                var position = await _blPosition.ReadAsync(blv.PositionCode.Value);
//                blv.PositionName = position?.positionName;
//            }

//            return blv;
//        }

//        private async Task<List<BLVolunteerModel>> ConvertToBlListAsync(IEnumerable<Volunteer> list)
//        {
//            if (list == null) return new List<BLVolunteerModel>();
//            var tasks = list.Select(ConvertToBlAsync);
//            return (await Task.WhenAll(tasks)).ToList();
//        }

//        public async Task CreateAsync(BLVolunteerModel item)
//        {
//            if (item == null) throw new ArgumentNullException(nameof(item));

//            if (item.VolunteerDomains != null)
//            {
//                foreach (var domain in item.VolunteerDomains)
//                {
//                    await _blDomain.CreateAsync(domain);
//                }
//            }

//            await _volunteerDal.CreateAsync(ConvertToDal(item));
//        }

//        public async Task DeleteAsync(BLVolunteerModel item)
//        {
//            if (item == null) throw new ArgumentNullException(nameof(item));
//            await _volunteerDal.DeleteAsync(ConvertToDal(item));
//        }

//        public async Task<BLVolunteerModel> ReadAsync(int id)
//        {
//            try
//            {
//                var vol = await _volunteerDal.ReadAsync(id);
//                return await ConvertToBlAsync(vol);
//            }
//            catch (ObjectNotFoundException)
//            {
//                return null;
//            }
//        }

//        public async Task<List<BLVolunteerModel>> ReadAsync(Func<BLVolunteerModel, bool> predicate)
//        {
//            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

//            var vols = await _volunteerDal.ReadAllAsync();
//            var converted = await ConvertToBlListAsync(vols);
//            return converted.Where(predicate).ToList();
//        }

//        public async Task<List<BLVolunteerModel>> ReadAllAsync()
//        {
//            var vols = await _volunteerDal.ReadAllAsync();
//            return await ConvertToBlListAsync(vols);
//        }

//        public async Task UpdateAsync(BLVolunteerModel item)
//        {
//            if (item == null) throw new ArgumentNullException(nameof(item));

//            if (item.VolunteerDomains != null)
//            {
//                foreach (var domain in item.VolunteerDomains)
//                {
//                    await _blDomain.CreateAsync(domain);
//                }
//            }

//            await _volunteerDal.UpdateAsync(ConvertToDal(item));
//        }
//    }
//}
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
    public class BLVolunteerService : BlVolunteerInterface
    {
        DalVolunteerInterface Volunteer;
        BlEichudInterface BlEichud;
        BlVolunteerDomainInterface BlDomain;
        BlPositionInterface BlPosition;

        public BLVolunteerService(IDal dal, BlEichudInterface blEichud, BlVolunteerDomainInterface _blDomain, BlPositionInterface blPosition)
        {
            this.Volunteer = dal.Volunteer;
            this.BlEichud = blEichud;
            this.BlDomain = _blDomain;
            this.BlPosition = blPosition;
        }
        private async Task<Volunteer> ConvertAsync(BLVolunteerModel v)
        {
            return new Volunteer()
            {
                VolunteerCode = v.VolunteerCode,
                PositionCode = v.PositionCode,
                VolunteerDomains = v.VolunteerDomains.Select(x => ((BlVolunteerDomainService)BlDomain).Convert(x)).ToList()
            };
        }
        private async Task<BLVolunteerModel> ConvertAsync(Volunteer v)
        {
            BLVolunteerModel blv = new BLVolunteerModel()
            {
                VolunteerCode = v.VolunteerCode,
                PositionCode = v.PositionCode,
                VolunteerCodeNavigation = ((BlEichudService)BlEichud).convert(v.VolunteerCodeNavigation),
                VolunteerDomains = v.VolunteerDomains.Select(x => ((BlVolunteerDomainService)BlDomain).Convert(x)).ToList()
            };
            if (blv.PositionCode != null)
            {
                blv.PositionName = ((BlPositionService)BlPosition).ReadAsync(v.PositionCode ?? 0).Result.positionName;
            }
            return blv;
        }
        private async Task<List<BLVolunteerModel>> Convert(List<Volunteer> c)
        {
            List<BLVolunteerModel> list = new List<BLVolunteerModel>();
            foreach (var item in c)
            {
                list.Add(await ConvertAsync(item));
            }
            return list;
        }

        public async Task CreateAsync(BLVolunteerModel item)

        {
            item.VolunteerDomains.ToList().ForEach(x => BlDomain.CreateAsync(x));
            Volunteer.CreateAsync(await ConvertAsync(item));
        }

        public async Task DeleteAsync(BLVolunteerModel item)
        {
            Volunteer.DeleteAsync(await ConvertAsync(item));
        }

        public async Task<BLVolunteerModel> ReadAsync(int id)
        {

            try { return await ConvertAsync(Volunteer.ReadAsync(id).Result).ConfigureAwait(false); }
            catch (ObjectNotFoundException e)
            {
                return null;
            }
        }

        public async Task<List<BLVolunteerModel>> ReadAsync(Func<BLVolunteerModel, bool> func)
        {
            List<BLVolunteerModel> list = await Convert( Volunteer.ReadAsync((Func<Volunteer, bool>)func).Result).ConfigureAwait(false);
            return list;
        }

        public async Task<List<BLVolunteerModel>> ReadAllAsync()
        {
            var list = await Volunteer.ReadAllAsync();

            var result = new List<BLVolunteerModel>();

            foreach (var item in list)
            {
                result.Add(await ConvertAsync(item));
            }

            return result;
        }

        public async Task UpdateAsync(BLVolunteerModel item)
        {
            item.VolunteerDomains.ToList().ForEach(x => BlDomain.CreateAsync(x));
            var tt = ConvertAsync(item);

            Volunteer.UpdateAsync(await tt);
        }
    }
}
