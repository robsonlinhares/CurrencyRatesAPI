using CurrencyRates.Domain.Dtos;
using CurrencyRates.Domain.Interfaces;
using CurrencyRates.Domain.Interfaces.Repositories;
using CurrencyRates.Domain.Interfaces.Services;
using CurrencyRates.Domain.Models;

namespace CurrencyRates.Domain.Services
{
    public class CurrencyTransactionService : ICurrencyTransactionService
    {
        private readonly INotifier _notifier;
        private readonly IUserRepository _userRepository;
        private readonly IExchangeRateApiIntegrationRepository _exchangeRateApiIntegrationRepository;
        private readonly ICurrencyTransactionRepository _currencyTransactionRepository;

        public CurrencyTransactionService(INotifier notifier,
                                          IUserRepository userRepository,
                                          IExchangeRateApiIntegrationRepository exchangeRateApiIntegrationRepository,
                                          ICurrencyTransactionRepository currencyTransactionRepository)
        {
            _notifier = notifier;
            _userRepository = userRepository;
            _exchangeRateApiIntegrationRepository = exchangeRateApiIntegrationRepository;
            _currencyTransactionRepository = currencyTransactionRepository;
        }

        public async Task CurrencyConversion(CurrencyTransactionDto currencyTransactionDto)
        {
            var user = await _userRepository.GetById(currencyTransactionDto.UserId);

            if (user == null)
            {
                _notifier.Notify($"User not found. UserID: {currencyTransactionDto.UserId}");
                return;
            }

            var rate = await _exchangeRateApiIntegrationRepository.GetExchangeRate(currencyTransactionDto.FromCurrency, currencyTransactionDto.ToCurrency);
            var currencyTransaction = await CreateCurrencyTransaction(currencyTransactionDto);

            if (currencyTransaction.CalculateRate(rate))
                await _currencyTransactionRepository.Add(currencyTransaction);

        }

        private async Task<CurrencyTransaction> CreateCurrencyTransaction(CurrencyTransactionDto currencyTransactionDto)
        {
            return await Task.FromResult(new CurrencyTransaction
            {
                CreatedAt = DateTime.Now.ToUniversalTime(),
                FromCurrency = currencyTransactionDto.FromCurrency,
                ToCurrency = currencyTransactionDto.ToCurrency,
                FromValue = currencyTransactionDto.FromValue,
                UserId = currencyTransactionDto.UserId
            });
        }
    }
}
