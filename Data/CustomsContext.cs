using CustomsSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomsSystem.Data
{
    public class CustomsContext : DbContext
    {
        const string conn = "Server=localhost; User ID=root; Password=12345678; Database=CUSTOMS_SYSTEM";
        public DbSet<BillOfLading> Bills { get; set; }

        public DbSet<Container> Containers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillOfLading>().HasMany(e => e.Containers).WithOne().IsRequired();
        }
    }
}
