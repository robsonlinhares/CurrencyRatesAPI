using CurrencyRates.Domain.Models;

namespace CurrencyRates.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(string email);
    }
}
