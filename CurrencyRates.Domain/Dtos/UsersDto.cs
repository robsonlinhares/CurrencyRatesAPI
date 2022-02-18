namespace CurrencyRates.Domain.Dtos
{
    public class UsersDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
