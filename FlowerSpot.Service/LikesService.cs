using AutoMapper;
using FlowerSpot.Data;
using FlowerSpot.Data.Entities;
using FlowerSpot.Domain.Likes;
using FlowerSpot.Service.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FlowerSpot.Service
{
    public class LikesService : ILikesService
    {
        private readonly FlowerSpotDbContext _context;
        private readonly IMapper _mapper;

        public LikesService(FlowerSpotDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LikeModel>> GetForUserAsync(string userId)
        {
            var like = await _context.Likes
                .AsNoTracking()
                .Include(x => x.Sighting)
                .ThenInclude(x => x.SightingQuote)
                .Include(x => x.Sighting)
                .ThenInclude(x => x.Flower)
                .Where(x => x.UserId == userId).ToListAsync();

            return _mapper.Map<List<LikeModel>>(like);
        }

        public async Task<LikeModel> GetByIdAsync(int id)
        {
            var like = await _context.Likes
                .AsNoTracking()
                .Include(x => x.Sighting)
                .ThenInclude(x => x.SightingQuote)
                .Include(x => x.Sighting)
                .ThenInclude(x => x.Flower)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<LikeModel>(like);
        }


        public async Task<LikeModel> CreateAsync(int sightingId, string userId)
        {
            if (_context.Likes.Any(x => x.UserId == userId && x.SightingId == sightingId))
            {
                throw new Exception("You have already liked this sighting");
            }

            var like = new Like
            {
                SightingId = sightingId,
                UserId = userId,
                Created = DateTime.UtcNow
            };

            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(like.Id);
        }

        public async Task<DeleteLikeResponseModel> DeleteAsync(int id, string userId)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(x => x.Id == id);

            if (like is null)
            {
                throw new Exception($"Like with Id: {id} has not been found");
            }

            if (like.UserId != userId)
            {
                throw new UnauthorizedAccessException("You're not allowed to delete this like");
            }

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();

            return new DeleteLikeResponseModel { Message = "Like has been deleted." };
        }
    }
}