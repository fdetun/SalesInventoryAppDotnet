

using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users{ get; set; }
        public DbSet<Devis> Devis{ get; set; }
        public DbSet<Article> Article{ get; set; }
        public DbSet<Client> Client{ get; set; }


    }
}