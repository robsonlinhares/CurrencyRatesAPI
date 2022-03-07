using CurrencyRates.Domain.Dtos;
using CurrencyRates.Domain.Interfaces.Repositories;
using CurrencyRates.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace CurrencyRates.Infraestructure.Repositories
{
    public class ExchangeRateApiIntegrationRepository : IExchangeRateApiIntegrationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseRequestService _baseRequestService;

        public ExchangeRateApiIntegrationRepository(IConfiguration configuration,
                                                    IBaseRequestService baseRequestService)
        {
            _configuration = configuration;
            _baseRequestService = baseRequestService;
        }

        public async Task<double> GetExchangeRate(string fromCurrency, string toCurrency)
        {
            var apiLayerDto = new ApiLayerDto();
            var endpoint = await GetApiLayerUrl(fromCurrency, toCurrency);
            apiLayerDto = await _baseRequestService.PostAsync<ApiLayerDto>(apiLayerDto, endpoint);


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
