using FlowerSpot.Domain.Likes;

namespace FlowerSpot.Service.Abstractions
{
    public interface ILikesService
    {
        Task<IEnumerable<LikeModel>> GetForUserAsync(string userId);

        Task<LikeModel> GetByIdAsync(int id);

        Task<LikeModel> CreateAsync(int sightingId, string userId);

        Task<DeleteLikeResponseModel> DeleteAsync(int id, string userId);
    }
}