using RacersCommunity.Data.Enum;
using RacersCommunity.Data;
using RacersCommunity.Interfaces;
using RacersCommunity.Models;
using Microsoft.EntityFrameworkCore;

namespace RacersCommunity.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDBContext _context;

        public RaceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool Add(Race race)
        {
            _context.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _context.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Race.ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
        {
            return await _context.Race.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Race?> GetByIdAsync(int id)
        {
            return await _context.Race.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Race?> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Race.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Race.CountAsync();
        }

        public async Task<int> GetCountByCategoryAsync(RaceCategory category)
        {
            return await _context.Race.CountAsync(r => r.RaceCategory == category);
        }

        public async Task<IEnumerable<Race>> GetSliceAsync(int offset, int size)
        {
            return await _context.Race.Include(a => a.Address).Skip(offset).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetRacesByCategoryAndSliceAsync(RaceCategory category, int offset, int size)
        {
            return await _context.Race
                .Where(r => r.RaceCategory == category)
                .Include(a => a.Address)
                .Skip(offset)
                .Take(size)
                .ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Race race)
        {
            _context.Update(race);
            return Save();
        }
    }
}
