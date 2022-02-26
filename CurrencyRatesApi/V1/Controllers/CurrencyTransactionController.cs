using CurrencyRates.Api.Controllers;
using CurrencyRates.Domain.Dtos;
using CurrencyRates.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyRates.Api.V1.Controllers
{
    public class CurrencyTransactionController : MainController
    {
        private readonly INotifier _notifier;
        public CurrencyTransactionController(INotifier notifier): base(notifier)
        {
            _notifier = notifier;
        }

        [HttpPost("currency-transaction")]
        [AllowAnonymous]
        public async Task<ActionResult> CurrencyTransaction(CurrencyTransactionDto currencyTransactionDto)
        {          
            if (_notifier.HasNotification())
                return CustomResponse();

            return CustomResponse();
        }
    }
}
