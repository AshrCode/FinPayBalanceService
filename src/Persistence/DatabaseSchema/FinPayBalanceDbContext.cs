using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DatabaseSchema
{
    public class FinPayBalanceDbContext : DbContext
    {
        public FinPayBalanceDbContext(DbContextOptions<FinPayBalanceDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<UserAccount> UserAccounts { get; set; }

    }
}
