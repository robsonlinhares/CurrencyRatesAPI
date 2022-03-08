using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyRates.Domain.Models
{
    public class CurrencyTransaction : Entity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string FromCurrency { get; set; }
        public double FromValue { get; set; }
        public string ToCurrency { get; set; }
        public double ConvertionRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public double ToValue { get; set; }      

        public bool CalculateRate(double rate)
        {
            if (rate > 0)
            {
                ConvertionRate = rate;
                ToValue = FromValue * rate;
            }

            return rate > 0;
        }
    }
}
