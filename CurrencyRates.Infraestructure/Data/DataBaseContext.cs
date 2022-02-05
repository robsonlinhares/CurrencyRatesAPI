using CurrencyRates.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyRates.Infraestructure.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> configuration): base(configuration)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
    }
}
