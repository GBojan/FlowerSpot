using FlowerSpot.Domain.Flowers;

namespace FlowerSpot.Service.Abstractions
{
    public interface IFlowerService
    {
        Task<IEnumerable<FlowerModel>> GetAllAsync();

        Task<FlowerModel> GetByIdAsync(int id);

        Task<FlowerModel> CreateAsync(CreateFlowerModel model, string userId);
    }
}