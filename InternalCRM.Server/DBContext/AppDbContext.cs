using InternalCRM.Server.Entities;
using Microsoft.EntityFrameworkCore;
namespace InternalCRM.Server.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.Id); // Primary key
            });
        }
    }
}
