namespace CurrencyRates.Domain.Models
{
    public class CurrencyTransaction : Entity
    {
        public Guid UserId { get; set; }
        public string FromCurrency { get; set; }
        public double FromValue { get; set; }
        public string ToCurrency { get; set; }
        public double ConvertionRate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
