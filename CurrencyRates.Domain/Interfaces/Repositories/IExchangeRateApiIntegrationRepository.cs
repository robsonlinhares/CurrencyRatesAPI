namespace CurrencyRates.Domain.Interfaces.Repositories
{
    public interface IExchangeRateApiIntegrationRepository
    {
        Task<double> GetExchangeRate(string fromCurrency, string toCurrency);
    }
}
