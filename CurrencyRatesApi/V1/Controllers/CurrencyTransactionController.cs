using CurrencyRates.Api.Controllers;
using CurrencyRates.Domain.Dtos;
using CurrencyRates.Domain.Interfaces;
using CurrencyRates.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyRates.Api.V1.Controllers
{
    public class CurrencyTransactionController : MainController
    {
        private readonly INotifier _notifier;
        private readonly ICurrencyTransactionService _currencyTransactionService;
        public CurrencyTransactionController(INotifier notifier,
                                             ICurrencyTransactionService currencyTransactionService) : base(notifier)
        {
            _notifier = notifier;
            _currencyTransactionService = currencyTransactionService;
        }

        [HttpPost("currency-transaction")]
        [AllowAnonymous]
        public async Task<ActionResult> CurrencyTransaction(CurrencyTransactionDto currencyTransactionDto)
        {          
            if (_notifier.HasNotification())
                return CustomResponse();

            await _currencyTransactionService.CurrencyConversion(currencyTransactionDto);

            return CustomResponse();
        }
    }
}
