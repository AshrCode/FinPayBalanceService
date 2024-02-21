using Application.AccountBalance;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Application
{
    public static class ApplicationDependencyInjector
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAccountBalanceApp, AccountBalanceApp>();

            services.AddPersistenceDependencies(connectionString);

            return services;
        }
    }
}
