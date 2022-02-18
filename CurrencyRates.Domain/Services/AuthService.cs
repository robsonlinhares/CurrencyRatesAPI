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

        public async Task<User> CreateUser(RegisterUserDto registerUser)
        {
            var user = await _userRepository.GetUserByEmail(registerUser.Email);

            if (user != null)
            {
                _notifier.Notify($"E-mail already registered. {registerUser.Email}");
                return new User();
            }

            user = await CreateUserDomain(registerUser);

            await _userRepository.Add(user);

            return user;
        }

        public async Task<User> Login(LoginUserDto loginUserDto)
        {
            var user = await _userRepository.Login(loginUserDto.Email, loginUserDto.Password);

            if (user == null)
            {
                _notifier.Notify($"E-mail or password invalid. {loginUserDto.Email}");
                return new User();
            }

            return user;
        }

        public async Task<IEnumerable<UsersDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();

            if (!users.Any())
            {
                _notifier.Notify($"Users not found in database");
                return new List<UsersDto>();
            }

            return await GetUsersDto(users);
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

        private async Task<IEnumerable<UsersDto>> GetUsersDto(IEnumerable<User> users)
        {
            return await Task.FromResult(users.Select
                                        (u => new UsersDto
                                        {
                                            Id = u.Id,
                                            Email = u.Email,
                                            Active = u.Active,
                                            Role = u.Role,
                                            CreatedAt = u.CreatedAt
                                        }));
        }
    }
}
