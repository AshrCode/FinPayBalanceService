using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DatabaseSchema
{
    public class FinPayBalanceDbContext : DbContext
    {
        public FinPayBalanceDbContext(DbContextOptions<FinPayBalanceDbContext> options)
            : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Seeding data
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount {

                    Id = new Guid("B136CF3D-766B-45AE-AA84-AC7F10C5A090"),
                    Balance = 5000,
                    Currency = "AED"
                },
                new UserAccount {

                    Id = new Guid("6751304E-0EEA-443C-AD6A-DFBBF53731FE"),
                    Balance = 700,
                    Currency = "AED"
                }
            );
        }

    }
}
