using Domain.Entities;

namespace Persistence.Account
{
    public interface IAccountRepository
    {
        Task<UserAccount> GetById(Guid id);
    }
}
