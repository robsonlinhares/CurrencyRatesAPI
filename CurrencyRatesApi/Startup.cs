using CurrencyRates.Api.Configurations;

namespace CurrencyRates.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.ResolveDependencies();
            services.AddCustomDatabase(Configuration);
            services.AddSwaggerGen();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
