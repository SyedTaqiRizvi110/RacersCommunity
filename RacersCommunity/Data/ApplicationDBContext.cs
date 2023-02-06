using Microsoft.EntityFrameworkCore;
using RacersCommunity.Models;

namespace RacersCommunity.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Address> Address { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Club> Club { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<State> State { get; set; }
    }
}
