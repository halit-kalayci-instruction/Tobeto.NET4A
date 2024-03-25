using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework
{
    // Veritabanını temsil eden dosya
    public class BaseDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=Tobeto4A; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
