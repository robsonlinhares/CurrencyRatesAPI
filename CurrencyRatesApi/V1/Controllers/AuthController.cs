using CurrencyRates.Api.Controllers;
using CurrencyRates.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyRates.Api.V1.Controllers
{

    [Route("api/v1")]
    public class AuthController : MainController
    {
        public AuthController(INotifier notifier) : base(notifier)
        {

        }

        [HttpGet()]
        public string Get()
        {
            return "Rob";
        }

        //public async Task<ActionResult>Register()
        //{


        //    return CustomResponse(Ok());
        //}
    }
}
