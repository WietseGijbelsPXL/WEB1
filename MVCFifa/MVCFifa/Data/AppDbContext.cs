using Microsoft.EntityFrameworkCore;
using MVCFifa.Models;

namespace MVCFifa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
