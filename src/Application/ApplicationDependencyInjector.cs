using Application.AccountBalance;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationDependencyInjector
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAccountBalanceApp, AccountBalanceApp>();

            return services;
        }
    }
}
