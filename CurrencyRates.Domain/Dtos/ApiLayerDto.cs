using System.Text.Json.Serialization;

namespace CurrencyRates.Domain.Dtos
{
    public class ApiLayerDto
    {
        [JsonPropertyName("success")]
        public string Success { get; set; }

        [JsonPropertyName("terms")]
        public string Terms { get; set; }

        [JsonPropertyName("privacy")]
        public string Privacy { get; set; }

        [JsonPropertyName("timeStamp")]
        public int TimeStamp { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        // public IEnumerable<RatesDto> Quotes { get; set; }
        [JsonPropertyName("quotes")]
        public IDictionary<string, double> Quotes { get; set; }
    }
}
