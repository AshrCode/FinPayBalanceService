using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Account;
using Persistence.DatabaseSchema;

namespace Persistence
{
    public static class PersistenceDependencyInjector
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FinPayBalanceDbContext>(options => options.UseSqlServer(connectionString));


            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
