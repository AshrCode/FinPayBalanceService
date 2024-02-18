using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.AccountBalance
{
    public class AccountBalanceApp : IAccountBalanceApp
    {
        private readonly ILogger _logger;
        private static float _balanceStorage = 6000;

        public AccountBalanceApp(ILogger<AccountBalanceApp> logger)
        {
            _logger = logger;
        }

        public Task<UserAccount> GetAsync(Guid userId)
        {
            UserAccount userAccount = new()
            {
                Balance = _balanceStorage,
                Id = userId
            };

            return Task.FromResult(userAccount);
        }

        public Task<UserAccount> DebitAmount(Guid userId, float amountToDebit)
        {
            _balanceStorage -= amountToDebit;
            UserAccount userAccount = new()
            {
                Balance = _balanceStorage,
                Id = userId
            };

            _logger.LogInformation($"Amount of {userAccount.Currency} {amountToDebit} has been debited from the account of the User {userId}");

            return Task.FromResult(userAccount);
        }
    }
}
