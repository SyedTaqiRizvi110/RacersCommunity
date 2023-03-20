using Microsoft.EntityFrameworkCore;
using RacersCommunity.Data;
using RacersCommunity.Data.Enum;
using RacersCommunity.Interfaces;
using RacersCommunity.Models;

namespace RacersCommunity.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDBContext _Context;

        public ClubRepository(ApplicationDBContext Context)
        {
            _Context = Context;
        }

        public bool Add(Club club)
        {
            _Context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _Context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _Context.Club.ToListAsync();
        }

        public async Task<List<City>> GetAllCitiesByState(string state)
        {
            return await _Context.City.Where(x => x.StateCode.Contains(state)).ToListAsync();
        }

        public async Task<List<State>> GetAllStates()
        {
            return await _Context.State.ToListAsync();
        }

        public async Task<Club?> GetByIdAsync(int id)
        {
            return await _Context.Club.Include(x => x.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Club?> GetByIdAsyncNoTracking(int id)
        {
            return await _Context.Club.Include(x => x.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _Context.Club.Where(x => x.Address.City.Contains(city)).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<Club>> GetClubsByCategoryAndSliceAsync(ClubCategory category, int offset, int size)
        {
            return await _Context.Club.Include(x => x.Address).Where(x => x.ClubCategory == category)
                .Skip(offset).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Club>> GetClubsByState(string state)
        {
            return await _Context.Club.Where(x => x.Address.State.Contains(state)).ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _Context.Club.CountAsync();
        }

        public async Task<int> GetCountByCategoryAsync(ClubCategory category)
        {
            return await _Context.Club.CountAsync(x => x.ClubCategory == category);
        }

        public async Task<IEnumerable<Club>> GetSliceAsync(int offset, int size)
        {
            return await _Context.Club.Include(x => x.Address).Skip(offset).Take(size).ToListAsync();
        }

        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Club club)
        {
            _Context.Update(club);
            return Save();
        }
    }
}
