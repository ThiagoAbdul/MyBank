using Microsoft.EntityFrameworkCore;
using MyBank.Models;

namespace MyBank.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Account> Accounts{ get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey("Id");
                e.HasIndex("Email");
                
            });
            modelBuilder.Entity<Account>(e => 
            {
                e.HasKey("Id");
                e.HasOne(a => a.Customer);
            });
        }

    }
}
