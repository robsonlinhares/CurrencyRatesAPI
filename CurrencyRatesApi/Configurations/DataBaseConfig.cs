using CurrencyRates.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CurrencyRates.Api.Configurations
{
    public static class DataBaseConfig
    {
        public static void AddCustomDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration["DatabaseConnection:Sqlite"];
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlite(connection)
            );
        }
    }
}
