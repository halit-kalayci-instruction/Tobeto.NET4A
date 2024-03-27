using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework
{
    // Veritabanını temsil eden dosya
    public class BaseDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=Tobeto4A2; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
