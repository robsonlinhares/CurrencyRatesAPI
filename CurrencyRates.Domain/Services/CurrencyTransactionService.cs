using CurrencyRates.Domain.Dtos;
using CurrencyRates.Domain.Interfaces;
using CurrencyRates.Domain.Interfaces.Repositories;
using CurrencyRates.Domain.Interfaces.Services;

namespace CurrencyRates.Domain.Services
{
    public class CurrencyTransactionService : ICurrencyTransactionService
    {
        private readonly INotifier _notifier;
        private readonly IUserRepository _userRepository;
        private readonly IExchangeRateApiIntegrationRepository _exchangeRateApiIntegrationRepository;

        public CurrencyTransactionService(INotifier notifier,
                                          IUserRepository userRepository,
                                          IExchangeRateApiIntegrationRepository exchangeRateApiIntegrationRepository)
        {
            _notifier = notifier;
            _userRepository = userRepository;
            _exchangeRateApiIntegrationRepository = exchangeRateApiIntegrationRepository;
        }

        public async Task CurrencyConversion(CurrencyTransactionDto currencyTransactionDto)
        {
            var user = await _userRepository.GetById(currencyTransactionDto.UserId);
            
            if(user == null)
            {
                _notifier.Notify($"User not found. UserID: {currencyTransactionDto.UserId}");
                return;
            }

            var teste = await _exchangeRateApiIntegrationRepository.GetExchangeRate(currencyTransactionDto.FromCurrency, currencyTransactionDto.ToCurrency);


        }
    }
}
