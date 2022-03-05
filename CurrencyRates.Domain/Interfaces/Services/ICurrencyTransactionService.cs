using CurrencyRates.Domain.Dtos;

namespace CurrencyRates.Domain.Interfaces.Services
{
    public interface ICurrencyTransactionService
    {
        Task CurrencyConversion(CurrencyTransactionDto currencyTransactionDto);
    }
}
