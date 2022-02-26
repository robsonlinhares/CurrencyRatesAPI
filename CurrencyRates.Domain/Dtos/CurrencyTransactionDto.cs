using System.ComponentModel.DataAnnotations;

namespace CurrencyRates.Domain.Dtos
{
    public class CurrencyTransactionDto
    {
        [Required(ErrorMessage = "The Field {0} is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "The Field {0} is required")]
        public string FromCurrency { get; set; }

        [Required(ErrorMessage = "The Field {0} is required")]
        public double FromValue { get; set; }

        [Required(ErrorMessage = "The Field {0} is required")]
        public string ToCurrency { get; set; }
    }
}
