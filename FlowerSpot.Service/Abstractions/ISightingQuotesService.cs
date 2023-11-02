namespace FlowerSpot.Service.Abstractions
{
    public interface ISightingQuotesService
    {
        Task CreateAsync(int sightingId);
    }
}