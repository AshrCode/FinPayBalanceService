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

        public async Task<UserAccount> DebitAmount(Guid userId, float amountToDebit)
        {
            // Validate and get user account
            var userAccount = await GetAsync(userId);

            // Verify the balance before debit.
            if(amountToDebit > userAccount.Balance)
            {
                var errMessage = $"User account {userId} doesn't have sufficient balance.";
                _logger.LogWarning(errMessage);
                throw new ApiException(ApiErrorCodes.BadRequest, errMessage);
            }

            userAccount.Balance -= amountToDebit;
            
            await _accountRepository.Save(userAccount);

            _logger.LogInformation($"Amount of {userAccount.Currency} {amountToDebit} has been debited from the user account {userId}");

            return userAccount;
        }
    }
}
