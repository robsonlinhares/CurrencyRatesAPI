﻿using CurrencyRates.Api.Controllers;
using CurrencyRates.Domain.Dtos;
using CurrencyRates.Domain.Interfaces;
using CurrencyRates.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
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
      

        [HttpPost("new-account")]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _authService.CreateUser(registerUserDto);

            if (_notifier.HasNotification())
                return CustomResponse();

            return CustomResponse(await _tokenService.GenerateToken(user));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginUserDto loginUserDto)
        {
            var user = await _authService.Login(loginUserDto);

            if (_notifier.HasNotification())
                return CustomResponse();


            return CustomResponse(await _tokenService.GenerateToken(user));
        }

        [HttpGet("get-all-users")]
        [Authorize]
        public async Task<ActionResult> GetAllUser()
        {                      
            return CustomResponse(await _authService.GetAllUsers());
        }
    }
}
