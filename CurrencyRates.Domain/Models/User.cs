﻿namespace CurrencyRates.Domain.Models
{
    public  class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
