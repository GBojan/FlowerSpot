namespace FlowerSpot.Service.Abstractions
{
    public interface IHttpClientService
    {
        Task<T> GetAsync<T>(string url, Dictionary<string, string> query) where T : class;
    }
}