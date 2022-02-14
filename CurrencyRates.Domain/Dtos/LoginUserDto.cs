using System.ComponentModel.DataAnnotations;

namespace CurrencyRates.Domain.Dtos
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "The Field {0} is required")]
        [EmailAddress(ErrorMessage = "The Field {0} is in an invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Field {0} is required")]
        [StringLength(100, ErrorMessage = "The Field {0} needs to have between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }             
    }
}
