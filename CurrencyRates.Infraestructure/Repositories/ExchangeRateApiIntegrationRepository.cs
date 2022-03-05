using CurrencyRates.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;

namespace CurrencyRates.Infraestructure.Repositories
{
    public class ExchangeRateApiIntegrationRepository : IExchangeRateApiIntegrationRepository
    {
        private readonly IConfiguration _configuration;

        public ExchangeRateApiIntegrationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<double> GetExchangeRate(string fromCurrency, string toCurrency)
        {
            var endpoint = GetApiLayerUrl(fromCurrency, toCurrency);



            return 0;
        }

        private async Task<string> GetApiLayerUrl(string fromCurrency, string toCurrency)
        {
            var url = _configuration["ExternalApi:Url"];
            var token = _configuration["ExternalApi:AccessKey"];
            var urlApi = $"{url}?access_key={token}&currencies={fromCurrency}&source={toCurrency}&format=1";

            return await Task.FromResult(urlApi);
        }
    }
}
