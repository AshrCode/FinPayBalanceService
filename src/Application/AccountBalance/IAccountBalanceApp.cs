using Domain.Entities;

namespace Application.AccountBalance
{
    public interface IAccountBalanceApp
    {
        Task<UserAccount> GetAsync(Guid userId);

        Task<UserAccount> DebitAmount(Guid userId, float amountToDebit);
    }
}
