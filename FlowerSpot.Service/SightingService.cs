using AutoMapper;
using FlowerSpot.Data;
using FlowerSpot.Data.Entities;
using FlowerSpot.Domain.Sightings;
using FlowerSpot.Service.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FlowerSpot.Service
{
    public class SightingService : ISightingService
    {
        private readonly FlowerSpotDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISightingQuotesService _sightingQuotesService;

        public SightingService(
            FlowerSpotDbContext context, 
            IMapper mapper,
            ISightingQuotesService sightingQuotesService)
        {
            _context = context;
            _mapper = mapper;
            _sightingQuotesService = sightingQuotesService;
        }

        public async Task<IEnumerable<SightingModel>> GetAllAsync()
        {
            var sightings = await _context.Sightings
                .AsNoTracking()
                .Include(x => x.Flower)
                .Include(x => x.SightingQuote)
                .Include(x => x.Likes)
                .ToListAsync();

            return _mapper.Map<List<SightingModel>>(sightings);
        }

        public async Task<SightingModel> GetByIdAsync(int id)
        {
            var sighting = await _context.Sightings
                .AsNoTracking()
                .Include(x => x.Flower)
                .Include(x => x.SightingQuote)
                .Include(x => x.Likes)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<SightingModel>(sighting);
        }

        public async Task<SightingModel> CreateAsync(CreateSightingModel model, string userId)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var sighting = _mapper.Map<Sighting>(model);
                sighting.UserId = userId;

                await _context.Sightings.AddAsync(sighting);
                await _context.SaveChangesAsync();

                await _sightingQuotesService.CreateAsync(sighting.Id);

                await _context.Database.CommitTransactionAsync();

                return await GetByIdAsync(sighting.Id);
            }
            catch (Exception)
            {
                await _context.Database.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<DeleteSightingResponseModel> DeleteAsync(int id, string userId)
        {
            var sighting = await _context.Sightings.FirstOrDefaultAsync(x => x.Id == id);

            if(sighting is null)
            {
                throw new Exception($"Sighting with Id: {id} has not been found");
            }

            if(sighting.UserId != userId)
            {
                throw new UnauthorizedAccessException("You're not allowed to delete this sighting");
            }

            _context.Sightings.Remove(sighting);
            await _context.SaveChangesAsync();

            return new DeleteSightingResponseModel { Message = "Sighting has been deleted."};
        }
    }
}