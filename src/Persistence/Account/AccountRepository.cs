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

        /// <summary>
        /// Adds or update a user account.
        /// </summary>
        public async Task Save(UserAccount account)
        {
            var userAccount = await GetById(account.Id);

            if (userAccount is null)
            {
                await _dbContext.UserAccounts.AddAsync(account);
            }
            else
            {
                userAccount.Balance = account.Balance;
                userAccount.Currency = account.Currency;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
