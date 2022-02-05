using CurrencyRates.Domain.Interfaces.Repositories;
using CurrencyRates.Domain.Models;
using CurrencyRates.Infraestructure.Data;

namespace CurrencyRates.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _databaseContext;

        public UserRepository(DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task CreateUser(User user)
        {
            await _databaseContext.User.AddAsync(user);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
