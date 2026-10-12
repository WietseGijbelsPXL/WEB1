using Microsoft.EntityFrameworkCore;
using WebAppMVCClientLocationEFCore.Models;

namespace WebAppMVCClientLocationEFCore.Data
{
    public class ClientLocationContext : DbContext
    {
        public ClientLocationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
