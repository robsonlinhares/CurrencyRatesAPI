using CurrencyRates.Domain.Dtos;
using CurrencyRates.Domain.Interfaces;
using CurrencyRates.Domain.Interfaces.Repositories;
using CurrencyRates.Domain.Interfaces.Services;
using CurrencyRates.Domain.Models;

namespace CurrencyRates.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly INotifier _notifier;
        private readonly IUserRepository _userRepository;        

        public AuthService(INotifier notifier,
                           IUserRepository userRepository)
        {
            _notifier = notifier;
            _userRepository = userRepository;            
        }

        public async Task CreateUser(RegisterUserDto registerUser)
        {
            var user = await _userRepository.GetUserByEmail(registerUser.Email);

            if (user != null)
            {
                _notifier.Notify($"E-mail already registered. {registerUser.Email}");
                return;
            }

            await _userRepository.CreateUser(await CreateUserDomain(registerUser));
        }

        private async Task<User> CreateUserDomain(RegisterUserDto registerUser)
        {
            var user = new User
            {
                Email = registerUser.Email,
                Password = registerUser.Password,
                Active = true,
                CreatedAt = DateTime.UtcNow,
                Role = "User"
            };

            return await Task.FromResult(user);
        }
    }
}
