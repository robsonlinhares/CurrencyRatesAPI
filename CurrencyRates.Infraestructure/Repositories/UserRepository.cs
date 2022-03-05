using CurrencyRates.Domain.Interfaces.Repositories;
using CurrencyRates.Domain.Models;
using CurrencyRates.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CurrencyRates.Infraestructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {       
        public UserRepository(DataBaseContext databaseContext): base(databaseContext)
        {            
        }      

        public async Task<User?> GetUserByEmail(string email) => await _databaseContext.User.FirstOrDefaultAsync(user => user.Email == email);

        public async Task<User?> Login(string email, string password) => await _databaseContext.User.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
    }
}
