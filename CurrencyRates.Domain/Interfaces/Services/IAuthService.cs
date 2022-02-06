using CurrencyRates.Domain.Dtos;

namespace CurrencyRates.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task CreateUser(RegisterUserDto registerUser);
    }
}
