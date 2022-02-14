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
        private readonly ITokenService _tokenService;
        private readonly INotifier _notifier;

        public AuthController(INotifier notifier,
                              IAuthService authService, 
                              ITokenService tokenService) : base(notifier)
        {
            _authService = authService;
            _tokenService = tokenService;
            _notifier = notifier;
        }

        [HttpGet()]
        public string Get()
        {
            return "Rob";
        }

        [HttpPost("new-account")]
        public async Task<ActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _authService.CreateUser(registerUserDto);

            if (_notifier.HasNotification())
                return CustomResponse();

            return CustomResponse(await _tokenService.GenerateToken(user));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserDto loginUserDto)
        {
            var user = await _authService.Login(loginUserDto);

            if (_notifier.HasNotification())
                return CustomResponse();


            return CustomResponse(await _tokenService.GenerateToken(user));
        }
    }
}
