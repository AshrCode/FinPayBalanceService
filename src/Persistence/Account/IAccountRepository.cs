using Domain.Entities;

namespace Persistence.Account
{
    public interface IAccountRepository
    {
        Task<UserAccount> GetById(Guid id);

        /// <summary>
        /// Adds or update a user account.
        /// </summary>
        Task Save(UserAccount account);
    }
}
