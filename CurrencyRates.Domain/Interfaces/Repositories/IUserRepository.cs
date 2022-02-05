using CurrencyRates.Domain.Models;

namespace CurrencyRates.Domain.Interfaces.Repositories
{
    public  interface IUserRepository
    {
        Task CreateUser(User user);
    }
}
