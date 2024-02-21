using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseSchema;

namespace Persistence.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FinPayBalanceDbContext _dbContext;

        public AccountRepository(FinPayBalanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserAccount> GetById(Guid id)
        {
            var userAccount = await _dbContext.UserAccounts.FirstOrDefaultAsync(x => x.Id == id);

            return userAccount;
        }
    }
}
