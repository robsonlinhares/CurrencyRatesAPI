using CurrencyRates.Api.Controllers;
using CurrencyRates.Domain.Dtos;
using CurrencyRates.Domain.Interfaces;
using CurrencyRates.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyRates.Api.V1.Controllers
{

    [Route("api/v1")]
    public class AuthController : MainController
    {
        private readonly IAuthService _authService;

        public AuthController(INotifier notifier, 
                              IAuthService authService) : base(notifier)
        {
            _authService = authService;
        }

        [HttpGet()]
        public string Get()
        {
            return "Rob";
        }

        [HttpPost()]
        public async Task<ActionResult> Register(RegisterUserDto registerUserDto)
        {
            await _authService.CreateUser(registerUserDto);

            return CustomResponse(Ok());
        }
    }
}
