using RacersCommunity.Data.Enum;
using RacersCommunity.Models;

namespace RacersCommunity.Interfaces
{
    public interface IRaceRepository
    {
        Task<int> GetCountAsync();

        Task<int> GetCountByCategoryAsync(RaceCategory category);

        Task<Race?> GetByIdAsync(int id);

        Task<Race?> GetByIdAsyncNoTracking(int id);

        Task<IEnumerable<Race>> GetAll();

        Task<IEnumerable<Race>> GetAllRacesByCity(string city);

        Task<IEnumerable<Race>> GetSliceAsync(int offset, int size);

        Task<IEnumerable<Race>> GetRacesByCategoryAndSliceAsync(RaceCategory category, int offset, int size);

        bool Add(Race race);

        bool Update(Race race);

        bool Delete(Race race);

        bool Save();
    }
}
