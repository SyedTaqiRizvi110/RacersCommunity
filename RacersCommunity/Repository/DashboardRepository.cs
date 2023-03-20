using RacersCommunity.Data;
using RacersCommunity.Interfaces;
using RacersCommunity.Models;

namespace RacersCommunity.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDBContext context, ApplicationDBContext httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = (IHttpContextAccessor?)httpContextAccessor; 
        }

        public async Task<List<Club>> GetAllUserClubs()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userClubs = _context.Club.Where(r => r.AppUser.Id == curUser);
            return userClubs.ToList();
        }

        public Task<List<Race>> GetAllUserRaces()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByIdNoTracking(string id)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
