using FlowerSpot.Domain.Sightings;

namespace FlowerSpot.Service.Abstractions
{
    public interface ISightingService
    {
        Task<IEnumerable<SightingModel>> GetAllAsync();

        Task<SightingModel> GetByIdAsync(int id);

        Task<SightingModel> CreateAsync(CreateSightingModel model, string userId);

        Task<DeleteSightingResponseModel> DeleteAsync(int id, string userId);
    }
}