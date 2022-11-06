using Microsoft.EntityFrameworkCore;
using SuperHeroes.Models;

namespace SuperHeroes.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Power> Powers { get; set; }
    }
}
