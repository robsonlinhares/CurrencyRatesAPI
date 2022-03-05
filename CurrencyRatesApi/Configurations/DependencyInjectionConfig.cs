using CurrencyRates.Domain.Interfaces;
using CurrencyRates.Domain.Interfaces.Repositories;
using CurrencyRates.Domain.Interfaces.Services;
using CurrencyRates.Domain.Notifications;
using CurrencyRates.Domain.Services;
using CurrencyRates.Infraestructure.Repositories;

namespace CurrencyRates.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICurrencyTransactionRepository, CurrencyTransactionRepository>();
            services.AddScoped<IExchangeRateApiIntegrationRepository, ExchangeRateApiIntegrationRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IBaseRequestService, BaseRequestService>();
            services.AddScoped<ICurrencyTransactionService, CurrencyTransactionService>();

            return services;
        }
    }
}
