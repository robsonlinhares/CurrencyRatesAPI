namespace CurrencyRates.Domain.Interfaces.Services
{
    public interface IBaseRequestService
    {
        HttpClient CreateHttpClient();
        Task<T> PostAsync<T>(object objeto, string url);
        Task<T> GetAsync<T>(string url);
    }
}
