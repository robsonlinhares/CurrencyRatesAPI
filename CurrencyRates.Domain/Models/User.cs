namespace CurrencyRates.Domain.Models
{
    public  class User : Entity
    {        
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
