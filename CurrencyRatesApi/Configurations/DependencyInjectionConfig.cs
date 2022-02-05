using CurrencyRates.Domain.Interfaces;
using CurrencyRates.Domain.Interfaces.Repositories;
using CurrencyRates.Domain.Notifications;
using CurrencyRates.Infraestructure.Repositories;

namespace CurrencyRates.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IUser, AspNetUser>();

            return services;
        }
    }
}
