using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace MatchDataManager.Api.Database
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
