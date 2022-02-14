using CurrencyRates.Domain.Dtos;
using CurrencyRates.Domain.Models;

namespace CurrencyRates.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User> CreateUser(RegisterUserDto registerUser);
        Task<User> Login(LoginUserDto loginUserDto);
    }
}
