using Common.ApiException;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Account;

namespace Application.AccountBalance
{
    public class AccountBalanceApp : IAccountBalanceApp
    {
        private readonly ILogger<AccountBalanceApp> _logger;
        private readonly IAccountRepository _accountRepository;

        private static float _balanceStorage = 6000;

        public AccountBalanceApp(ILogger<AccountBalanceApp> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task<UserAccount> GetAsync(Guid userId)
        {
            var userAccount = await _accountRepository.GetById(userId);

            if (userAccount is null)
            {
                var errMessage = $"Unable to find the user account {userId}";
                _logger.LogWarning(errMessage);
                throw new ApiException(ApiErrorCodes.BadRequest, errMessage);
            }

            return userAccount;
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
